<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminRespEncuestaCaract.aspx.cs" Inherits="AuditoriasCiudadanas.Views.Caracterizacion.AdminRespEncuestaCaract" %>

<div class="container">
<table id="example" class="table table-striped table-bordered" cellspacing="0" width="100%">
        <thead>
            <tr>
                <th data-toggle="tooltip" title="Nombre del ciudadano" data-placement="bottom">Nombre </th>
                <th data-toggle="tooltip" title="Correo electrónico" data-placement="bottom">Correo</th>
                <th data-toggle="tooltip" title="Fecha aplicación" data-placement="bottom">Fecha</th>
                <th data-toggle="tooltip" title="Municipio al que pertenece" data-placement="bottom">Localización</th>
                <th data-toggle="tooltip" title="Género" data-placement="bottom">P1</th>
                <th data-toggle="tooltip" title="Rango de edad" data-placement="bottom">P2</th>
                <th data-toggle="tooltip" title="Ocupación" data-placement="bottom">P3</th>
                <th data-toggle="tooltip" title="Actualmente usted reside en:" data-placement="bottom">P4</th>
                <th data-toggle="tooltip" title="¿Pertenece a una comunidad étnica minoritaria?" data-placement="bottom">P5</th>
                <th data-toggle="tooltip" title="¿Actualmente pertenece a alguna organización social o instancia de participación ciudadana?" data-placement="bottom">P6</th>
                <th data-toggle="tooltip" title="Mecanismos de participación ciudadana que ha promovido o en los que ha participado en los últimos tres años" data-placement="bottom">P7</th>
                <th data-toggle="tooltip" title="¿La Alcaldía cuenta con recursos destinados para la promoción de la participación ciudadana en su territorio?" data-placement="bottom">P8</th>
                <th data-toggle="tooltip" title="¿El DNP ha adelantado Auditorías Visibles en su municipio?" data-placement="bottom">P9</th>
                <th data-toggle="tooltip" title="La organización civil o instancia de participación con la que actualmente tiene vinculación, ¿cuenta con un plan de acción para orientar su labor de control social?" data-placement="bottom">P10</th>
                <th data-toggle="tooltip" title="Por favor seleccione las estrategias, mecanismos o instrumentos que utiliza la ciudadanía para reportar los hallazgos que obtienen de su ejercicio de control social" data-placement="bottom">P11</th>
                <th data-toggle="tooltip" title="Desde su perspectiva, por favor califique la gestión de las autoridades locales en el momento de promover el control ciudadano a la gestión pública o a proyectos específicos" data-placement="bottom">P12</th>
                <th data-toggle="tooltip" title="Por favor seleccione las estrategias, mecanismos o instrumentos que utiliza la ciudadanía para hacer seguimiento a la gestión o a proyectos de las autoridades locales" data-placement="bottom">P13</th>
                <th data-toggle="tooltip" title="Durante el año 2016, ¿usted ha radicado/presentado o ha tramitado una respuesta a al menos un derecho de petición donde se solicita el acceso a información específica o algún documento particular del municipio?" data-placement="bottom">P14</th>
                <th data-toggle="tooltip" title="Desde su experiencia, por favor califique la facilidad con la que se puede acceder a la información pública del municipio para hacer seguimiento a la gestión o proyectos de las autoridades locales" data-placement="bottom">P15</th>
                <th data-toggle="tooltip" title="¿La labor de control social de las organizaciones sociales o instancias de participación ha motivado algún cambio en la gestión o proyectos de las autoridades locales?" data-placement="bottom">P16</th>
                <th data-toggle="tooltip" title="Desde su experiencia, por favor califique la frecuencia con la que se hacen ejercicios de seguimiento a lo público o de control social sobre la gestión de las autoridades locales en su municipio" data-placement="bottom">P17</th>
                <th data-toggle="tooltip" title="Desde su percepción, ¿Usted considera que en su municipio existen condiciones adecuadas de seguridad para realizar control social?" data-placement="bottom">P18</th>
            </tr>
        </thead>
        <tfoot>
           <tr>
                <th data-toggle="tooltip" title="Nombre del ciudadano">Nombre </th>
                <th data-toggle="tooltip" title="Correo electrónico">Correo</th>
                <th data-toggle="tooltip" title="Fecha aplicación">Fecha</th>
                <th data-toggle="tooltip" title="Municipio al que pertenece">Localización</th>
                <th data-toggle="tooltip" title="Género">P1</th>
                <th data-toggle="tooltip" title="Rango de edad">P2</th>
                <th data-toggle="tooltip" title="Ocupación">P3</th>
                <th data-toggle="tooltip" title="Actualmente usted reside en:">P4</th>
                <th data-toggle="tooltip" title="¿Pertenece a una comunidad étnica minoritaria?">P5</th>
                <th data-toggle="tooltip" title="¿Actualmente pertenece a alguna organización social o instancia de participación ciudadana?">P6</th>
                <th data-toggle="tooltip" title="Mecanismos de participación ciudadana que ha promovido o en los que ha participado en los últimos tres años">P7</th>
                <th data-toggle="tooltip" title="¿La Alcaldía cuenta con recursos destinados para la promoción de la participación ciudadana en su territorio?">P8</th>
                <th data-toggle="tooltip" title="¿El DNP ha adelantado Auditorías Visibles en su municipio?">P9</th>
                <th data-toggle="tooltip" title="La organización civil o instancia de participación con la que actualmente tiene vinculación, ¿cuenta con un plan de acción para orientar su labor de control social?">P10</th>
                <th data-toggle="tooltip" title="Por favor seleccione las estrategias, mecanismos o instrumentos que utiliza la ciudadanía para reportar los hallazgos que obtienen de su ejercicio de control social">P11</th>
                <th data-toggle="tooltip" title="Desde su perspectiva, por favor califique la gestión de las autoridades locales en el momento de promover el control ciudadano a la gestión pública o a proyectos específicos">P12</th>
                <th data-toggle="tooltip" title="Por favor seleccione las estrategias, mecanismos o instrumentos que utiliza la ciudadanía para hacer seguimiento a la gestión o a proyectos de las autoridades locales">P13</th>
                <th data-toggle="tooltip" title="Durante el año 2016, ¿usted ha radicado/presentado o ha tramitado una respuesta a al menos un derecho de petición donde se solicita el acceso a información específica o algún documento particular del municipio?">P14</th>
                <th data-toggle="tooltip" title="Desde su experiencia, por favor califique la facilidad con la que se puede acceder a la información pública del municipio para hacer seguimiento a la gestión o proyectos de las autoridades locales">P15</th>
                <th data-toggle="tooltip" title="¿La labor de control social de las organizaciones sociales o instancias de participación ha motivado algún cambio en la gestión o proyectos de las autoridades locales?">P16</th>
                <th data-toggle="tooltip" title="Desde su experiencia, por favor califique la frecuencia con la que se hacen ejercicios de seguimiento a lo público o de control social sobre la gestión de las autoridades locales en su municipio">P17</th>
                <th data-toggle="tooltip" title="Desde su percepción, ¿Usted considera que en su municipio existen condiciones adecuadas de seguridad para realizar control social?">P18</th>
            </tr>
        </tfoot>
        <tbody>

        </tbody>
        </table>


</div>

<script>
    $(document).ready(function() {
    $('#example').DataTable();
    $('[data-toggle="tooltip"]').tooltip();
} );
</script>

