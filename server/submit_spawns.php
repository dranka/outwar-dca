<?
$path = 'quest.submitted';

$mobs = $_POST['mobs'];

if ($mobs != NULL)
{
	if (strlen($mobs) < 1)
	{
		return;
	}
$con=mysqli_connect("localhost","username","password","Database");
// Check connection
if (mysqli_connect_errno())
  {
  echo "Failed to connect to MySQL: " . mysqli_connect_error();
  }
  echo "Connected to db";
  
  	foreach(preg_split("/((\r?\n)|(\r\n?))/", $mobs) as $line){
    // do stuff with $line
      list($name, $level, $room) =
    split(";", $line, 3);

    mysqli_query($con,"INSERT INTO `Spawns`(`Name`, `Level`, `Room`) VALUES ('$name','$level','$room')");

} 
  mysqli_close($con);
}
?>
