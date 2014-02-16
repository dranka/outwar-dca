<?


$mobs = $_POST['mobs'];

if ($mobs != NULL)
{
	if (strlen($mobs) < 1)
	{
		return;
	}
$con=mysqli_connect("localhost","Username","Password","Database_Name");

if (mysqli_connect_errno())
  {
  echo "Failed to connect to MySQL: " . mysqli_connect_error();
  }
  echo "Connected to db";
  
  	foreach(preg_split("/((\r?\n)|(\r\n?))/", $mobs) as $line){
      list($name, $id, $room, $level, $rage) =
    split(";", $line, 5);
    mysqli_query($con,"INSERT INTO `Mobs`(`mobName`, `MobID`, `Room`, `Level`, `Rage`) VALUES ('$name','$id','$room','$level','$rage')");
} 
  mysqli_close($con);
}
?>
