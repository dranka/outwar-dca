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
      list($name, $id, $room) =
    split(";", $line, 3);
    if ($id !== "n/a" || $name !== "" || $name !== " ")
    {
    mysqli_query($con,"INSERT INTO `QuestMobs`(`MobName`, `MobID`, `MobRoom`) VALUES ('$name','$id','$room')");
    }
    //$fh = fopen($path, 'a') or die('can\'t open file - a');
	//fwrite($fh, $name);
	//fclose($fh);
} 
  mysqli_close($con);
}
?>
