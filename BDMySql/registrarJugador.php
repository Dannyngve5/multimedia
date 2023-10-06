<?php
$servidor = "localhost";
$baseDatos = "gamificacion";
$usuario = "root";
$pass = "";

// Datos del jugador a registrar
$nombre = "Nombre del Jugador";
$vida = 100; // Cambia esto según la vida que desees asignar
$nivel = 1; // Cambia esto según el nivel que desees asignar

try {
    $conn = mysqli_connect($servidor, $usuario, $pass, $baseDatos);

    if (!$conn) {
        echo '{"codigo" : 400, "mensaje" : "Error al conectar", "respuesta" : ""}';
    } else {
        // Preparar la consulta SQL para insertar un jugador
        $sql = "INSERT INTO jugador (nombre, Vida, Nivel) VALUES (?, ?, ?)";
        $stmt = mysqli_prepare($conn, $sql);

        if ($stmt) {
            // Bind de parámetros y ejecución de la consulta
            mysqli_stmt_bind_param($stmt, "sii", $nombre, $vida, $nivel);

            if (mysqli_stmt_execute($stmt)) {
                echo '{"codigo" : 200, "mensaje" : "Jugador registrado correctamente", "respuesta" : ""}';
            } else {
                echo '{"codigo" : 400, "mensaje" : "Error al registrar el jugador", "respuesta" : ""}';
            }

            mysqli_stmt_close($stmt);
        } else {
            echo '{"codigo" : 400, "mensaje" : "Error en la preparación de la consulta", "respuesta" : ""}';
        }

        mysqli_close($conn);
    }
} catch (Exception $e) {
    echo '{"codigo" : 400, "mensaje" : "Excepción capturada", "respuesta" : ""}';
}
?>