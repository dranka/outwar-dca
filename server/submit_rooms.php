<?

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
      list($id, $n, $s, $e, $w, $name) =
    split(",", $line, 6);
    mysqli_query($con,"INSERT INTO `Rooms`(`Name`, `ID`, `N`, `S`, `E`, `W`) VALUES ('$name','$id','$n','$s','$e','$w')");

} 
  mysqli_close($con);
}
?>
