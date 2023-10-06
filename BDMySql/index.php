<!DOCTYPE html>
<html lang="es">

<head>
    <meta charset="UTF-8">
    <title>Tabla de Jugadores</title>
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
</head>

<body>
    <table id="tablaJugadores" border="1">
        <thead>
            <tr>
                <th>ID</th>
                <th>Nombre</th>
                <th>Vida</th>
                <th>Nivel</th>
            </tr>
        </thead>
        <tbody></tbody>
    </table>

    <script>
        $(document).ready(function () {
            // Realizar una solicitud AJAX para obtener los datos de los jugadores desde el servidor
            $.ajax({
                url: 'obtener_jugadores.php', // Reemplaza 'obtener_jugadores.php' con la ruta correcta a tu archivo PHP que obtiene los datos de la base de datos
                type: 'GET', // Puedes cambiar el método HTTP según tus necesidades
                dataType: 'json',
                success: function (data) {