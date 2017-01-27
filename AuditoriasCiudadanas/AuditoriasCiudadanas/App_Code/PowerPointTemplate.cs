//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using DocumentFormat.OpenXml.Drawing;
//using System.IO;
//using DocumentFormat.OpenXml.Packaging;
//using DocumentFormat.OpenXml.Office2010.PowerPoint;
//using DocumentFormat.OpenXml.Presentation;
//using System.Collections;

//namespace PowerPointTemplates
//{
//    public class PowerPointTemplate
//    {

//        public PowerPointTemplate()
//        {
//            this.PowerPointParameters = new List<PowerPointParameter>();
//            this.SlideDictionary = new Dictionary<SlidePart, SlideId>();
//        }

//        public List<PowerPointParameter> PowerPointParameters { get; set; }

//        public Dictionary<SlidePart, SlideId> SlideDictionary { get; set; }

//        public void ParseTemplate(string templatePath, string templateOutputPath)
//        {
//            using (var templateFile = File.Open(templatePath, FileMode.Open, FileAccess.Read)) //read our template
//            {
//                using (var stream = new MemoryStream())
//                {
//                    templateFile.CopyTo(stream); //copy template

//                    using (var presentationDocument = PresentationDocument.Open(stream, true)) //open presentation document
//                    {
//                        // Get the presentation part from the presentation document.
//                        var presentationPart = presentationDocument.PresentationPart;

//                        //se clona el ultimo slide tantas tablas existan
//                        //CloneNumbersOfLastSLides(presentationPart,)
//                        //PowerPointParameters.


//                        // Get the presentation from the presentation part.
//                        var presentation = presentationPart.Presentation;

//                        var slideList = new List<SlidePart>();

//                        //get available slide list
//                        foreach (SlideId slideID in presentation.SlideIdList)
//                        {
//                            var slide = (SlidePart)presentationPart.GetPartById(slideID.RelationshipId);
//                            slideList.Add(slide);
//                            SlideDictionary.Add(slide, slideID);//add to dictionary to be used when needed
//                        }

//                         int count = 0;
//                        //loop all slides and replace images and texts
//                        foreach (var slide in slideList)
//                        {
//                            ReplaceImages(presentationDocument, slide, count); //replace images by name
                            
//                            var paragraphs = slide.Slide.Descendants<Paragraph>().ToList(); //get all paragraphs in the slide

//                            foreach (var paragraph in paragraphs)
//                            {
//                                ReplaceText(paragraph, count); //replace text by placeholder name
//                                ReplaceTable(paragraph, count); //replace Table by data
//                            }


//                            // paragraphs = slide.Slide.Descendants<Paragraph>().ToList(); //get the paragraphs not repleaced in the last iteration
//                            //foreach (var paragraph in paragraphs)
//                            //{
//                            //     ReplaceTable(paragraph, count); //replace Table by data
//                            //}
//                            count++;
//                        }

//                        var slideCount = presentation.SlideIdList.ToList().Count; //count slides
//                        //DeleteSlide(presentation, slideList[slideCount - 1]); //delete last slide

//                        presentation.Save(); //save document changes we've made
//                    }
//                    stream.Seek(0, SeekOrigin.Begin);//scroll to stream start point

//                    //save output file
//                    using (var fileStream = File.Create(templateOutputPath))
//                    {
//                        stream.CopyTo(fileStream);
//                    }
//                }
//            }
//        }


//        /// <summary>
//        /// Deletes slide from presentation
//        /// </summary>
//        /// <param name="presentation"></param>
//        /// <param name="slidePart"></param>
//        void DeleteSlide(Presentation presentation, SlidePart slidePart)
//        {
//            var delSlideID = SlideDictionary[slidePart];
//            presentation.SlideIdList.RemoveChild(delSlideID);
//        }

       
//        /// <summary>
//        /// Replaces slidePart images
//        /// </summary>
//        /// <param name="presentationDocument"></param>
//        /// <param name="slidePart"></param>
//        void ReplaceImages(PresentationDocument presentationDocument, SlidePart slidePart, int Slide)
//        {
//            // get all images in the slide
//            var imagesToReplace = slidePart.Slide.Descendants<Blip>().ToList();

//            if (imagesToReplace.Any())
//            {
//                var index = 0;//image index within the slide

//                //find all image names in the slide
//                var slidePartImageNames = slidePart.Slide.Descendants<DocumentFormat.OpenXml.Presentation.Picture>()
//                                        .Where(a => a.NonVisualPictureProperties.NonVisualDrawingProperties.Name.HasValue)
//                                        .Select(a => a.NonVisualPictureProperties.NonVisualDrawingProperties.Name.Value).Distinct().ToList();

//                //check all images in the slide and replace them if it matches our parameter
//                foreach (var imagePlaceHolder in slidePartImageNames)
//                {
//                    //check if we have image parameter that matches slide part image
//                    foreach (var param in PowerPointParameters)
//                    {
//                        //replace it if found by image name
//                        if (param.Image != null && param.Name.ToLower() == imagePlaceHolder.ToLower() && param.Slide != null && param.Slide == Slide)
//                        {
//                            var imagePart = slidePart.AddImagePart(ImagePartType.Jpeg); //add image to document

//                            using (FileStream imgStream = new FileStream(param.Image.FullName, FileMode.Open))
//                            {
//                                imagePart.FeedData(imgStream); //feed it with data
//                            }

//                            var relID = slidePart.GetIdOfPart(imagePart); // get relationship ID

//                            imagesToReplace.Skip(index).First().Embed = relID; //assign new relID, skip if this is another image in one slide part
//                        }
//                    }
//                    index += 1;
//                }
//            }
//        }

//        /// <summary>
//        /// Replace all text placeholders in paragraph
//        /// </summary>
//        /// <param name="paragraph"></param>
//        void ReplaceText(Paragraph paragraph, int Slide)
//        {
//            var parent = paragraph.Parent; //get parent element - to be used when removing placeholder
//            var dataParam = new PowerPointParameter();

//            if (ContainsParam(paragraph, ref dataParam,  Slide)) //check if paragraph is on our parameter list
//            {
//                //insert text list
//                if (dataParam.Name.Contains("string[]")) //check if param is a list
//                {
//                    var arrayText = dataParam.Text.Split(Environment.NewLine.ToCharArray()); //in our case we split it into lines

//                    if (arrayText is IEnumerable) //enumerate if we can
//                    {
//                        foreach (var itemData in arrayText)
//                        {
//                            Paragraph bullet = CloneParaGraphWithStyles(paragraph, dataParam.Name, itemData);// create new param - preserve styles
//                            parent.InsertBefore(bullet, paragraph); //insert new element
//                        }
//                    }
//                    paragraph.Remove();//delete placeholder
//                }
//                else
//                {
//                    //insert text line
//                    var param = CloneParaGraphWithStyles(paragraph, dataParam.Name, dataParam.Text); // create new param - preserve styles
//                    parent.InsertBefore(param, paragraph);//insert new element

//                    paragraph.Remove();//delete placeholder
//                }
//            }
//        }



//        /// <summary>
//        /// Replace all text placeholders in paragraph
//        /// </summary>
//        /// <param name="paragraph"></param>
//        void ReplaceTable(Paragraph paragraph, int Slide)
//        {
//            var parent = paragraph.Parent; //get parent element - to be used when removing placeholder
//            var dataParam = new PowerPointParameter();

//            if (ContainsParam(paragraph, ref dataParam, Slide)) //check if paragraph is on our parameter list
//            {
//                //insert text list
//                if (dataParam.Name.Contains("string[]")) //check if param is a list
//                {
//                    var arrayText = dataParam.Text.Split(Environment.NewLine.ToCharArray()); //in our case we split it into lines

//                    if (arrayText is IEnumerable) //enumerate if we can
//                    {
//                        foreach (var itemData in arrayText)
//                        {
//                            Paragraph bullet = CloneParaGraphWithStyles(paragraph, dataParam.Name, itemData);// create new param - preserve styles
//                            parent.InsertBefore(bullet, paragraph); //insert new element
//                        }
//                    }
//                    paragraph.Remove();//delete placeholder
//                }
//                else
//                {
//                    //insert text line
//                    var param = CloneParaGraphWithStyles(paragraph, dataParam.Name, dataParam.Text); // create new param - preserve styles
//                    parent.InsertBefore(param, paragraph);//insert new element

//                    paragraph.Remove();//delete placeholder
//                }
//            }
//        }

//        /// <summary>
//        /// Checks if process parameter to replace with text or image
//        /// </summary>
//        /// <param name="paragraph"></param>
//        /// <returns></returns>
//        public bool ContainsParam(Paragraph paragraph, ref PowerPointParameter dataParam, int Slide)
//        {
//            foreach (var param in this.PowerPointParameters)
//            {
//                if (!string.IsNullOrEmpty(param.Name) && !string.IsNullOrEmpty(param.Text) && paragraph.InnerText.ToLower().Contains(param.Name.ToLower()) && param.Slide==Slide)
//                {
//                    dataParam = param;
//                    return true;
//                }
//            }

//            return false;
//        }


//        /// <summary>
//        /// Checks if process parameter to replace with text or image
//        /// </summary>
//        /// <param name="paragraph"></param>
//        /// <returns></returns>
//        public bool ContainsParamTable(Paragraph paragraph, ref PowerPointParameter dataParam, int Slide)
//        {
//            foreach (var param in this.PowerPointParameters)
//            {
//                if (!string.IsNullOrEmpty(param.Name) && !string.IsNullOrEmpty(param.Text) && paragraph.InnerText.ToLower().Contains(param.Name.ToLower()) && param.Slide == Slide)
//                {
//                    dataParam = param;
//                    return true;
//                }
//            }

//            return false;
//        }


//        /// <summary>
//        /// Clones paragraph with styles
//        /// </summary>
//        /// <param name="sourceParagraph"></param>
//        /// <param name="text"></param>
//        /// <returns></returns>
//        public static Paragraph CloneParaGraphWithStyles(Paragraph sourceParagraph, string paramKey, string text)
//        {
//            var xmlSource = sourceParagraph.OuterXml;

//            xmlSource = xmlSource.Replace(paramKey.Trim(), text.Trim());

//            return new Paragraph(xmlSource);
//        }


//        public  SlidePart CloneSlide( SlidePart templatePart)
//        {
//            // find the presentationPart: makes the API more fluent
//            var presentationPart = templatePart.GetParentParts()
//                .OfType<PresentationPart>()
//                .Single();

//            // clone slide contents
//            Slide currentSlide = (Slide)templatePart.Slide.CloneNode(true);
//            var slidePartClone = presentationPart.AddNewPart<SlidePart>();
//            currentSlide.Save(slidePartClone);

//            // copy layout part
//            slidePartClone.AddPart(templatePart.SlideLayoutPart);

//            return slidePartClone;
//        }

//        public  void AppendSlide( PresentationPart presentationPart, SlidePart newSlidePart)
//        {
//            SlideIdList slideIdList = presentationPart.Presentation.SlideIdList;

//            // find the highest id
//            uint maxSlideId = slideIdList.ChildElements
//                .Cast<SlideId>()
//                .Max(x => x.Id.Value);

//            // Insert the new slide into the slide list after the previous slide.
//            var id = maxSlideId + 1;

//            SlideId newSlideId = new SlideId();
//            slideIdList.Append(newSlideId);
//            newSlideId.Id = id;
//            newSlideId.RelationshipId = presentationPart.GetIdOfPart(newSlidePart);
//        }

//        public  IEnumerable<SlidePart> GetSlidePartsInOrder( PresentationPart presentationPart)
//        {
//            SlideIdList slideIdList = presentationPart.Presentation.SlideIdList;

//            return slideIdList.ChildElements
//                .Cast<SlideId>()
//                .Select(x => presentationPart.GetPartById(x.RelationshipId))
//                .Cast<SlidePart>();
//        }

//        public void CloneNumbersOfLastSLides(PresentationPart presentationPart, int numberSlides) {

//            var templatePart = GetSlidePartsInOrder(presentationPart).Last();
//            var newSlidePart = CloneSlide(templatePart);
//            for (int i = 0; i < numberSlides; i++) {
//                AppendSlide(presentationPart, newSlidePart);
//            }
           
//        }

//        /// <summary>
//        /// Checks if process parameter to replace with text or image
//        /// </summary>
//        /// <param name="paragraph"></param>
//        /// <returns></returns>
//        public bool ContainsTableParagraph(Paragraph paragraph, ref PowerPointParameter dataParam, int Slide)
//        {
//            foreach (var param in this.PowerPointParameters)
//            {
//                if (!string.IsNullOrEmpty(param.Name) && !string.IsNullOrEmpty(param.Table) && paragraph.InnerText.ToLower().Contains(param.Name.ToLower()) && param.Slide == Slide)
//                {
//                    dataParam = param;
//                    return true;
//                }
//            }

//            return false;
//        }
//    }
//}
