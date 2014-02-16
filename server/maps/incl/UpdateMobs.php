<?php

$path = 'mobs';


mysql_connect("localhost","Username","Password");

mysql_select_db("Database_Name");
				
$order = "SELECT * FROM `Mobs` order by `MobID`";
				
$result = mysql_query($order);	
$fh = fopen($path, 'w') or die ('can\'t open file -a');	
fclose($fh);		
while($data = mysql_fetch_row($result)){
    $fh = fopen($path, 'a') or die('can\'t open file - a');
	fwrite($fh, "$data[0];$data[1];$data[2];$data[3];$data[4];\n");
	fclose($fh);
}


?>
