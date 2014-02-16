<?php
$path = 'dctopen.txt';

// load the data and delete the line from the array 
$lines = file("dctopen.txt"); 
$last = sizeof($lines) - 1 ; 
unset($lines[$last]); 

// write the new data to the file 
$fp = fopen('dctopen.txt', 'w'); 
fwrite($fp, implode('', $lines)); 
fclose($fp); 

$now = date("Y-m-d H:i");

$fWrite = fopen('dctopen.txt','a');
$wrote = fwrite($fWrite, "<map>$now</map>");
fclose($fWrite);

?>
