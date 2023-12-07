<?php
if (isset($_GET['text'])) {
    $url = 'https://api.cirrus.center/api/v1/edit/replace-space/?text=' . $_GET['text'];
    $ch = curl_init();

    curl_setopt($ch, CURLOPT_URL, $url);
    curl_setopt($ch, CURLOPT_RETURNTRANSFER, true);

    $result = curl_exec($ch);

    $httpCode = curl_getinfo($ch, CURLINFO_HTTP_CODE);

    if ($httpCode == 200) {
        $decodedResult = json_decode($result, true);

        if ($decodedResult !== null) {
            header('Content-Type: application/json');
            echo json_encode($decodedResult);
        } else {
            http_response_code(500);
            echo 'Error: Unable to decode JSON response.';
            echo 'HTTP Code: ' . $httpCode;
        }
    } else {
        http_response_code($httpCode);
        echo 'Error: Missing "text" parameter.';
        echo 'HTTP Code: ' . $httpCode;
    }

    curl_close($ch);
} else {
    http_response_code(400);
    echo 'Error: Missing "text" parameter.';
}
?>
