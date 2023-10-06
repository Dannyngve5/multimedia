<?php

$servidor = "localhost";
$baseDatos = "gamificacion";
$usuario = "root";
$pass = "";


try {
    $conn = mysqli_connect($servidor, $usuario, $pass, $baseDatos);
    if (!$conn) {
        echo '{ "codigo" : 400, "mensaje" : "Error al conectar", "respuesta" :"" }';
    } else {
        echo '{"codigo" : 200, "mensaje" : "Conectado correctamente", "respuesta" :"" }';
    }
} catch (Exception $e) {

}