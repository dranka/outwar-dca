<?php

$useragent = $_SERVER['HTTP_USER_AGENT'];
/*
if( $useragent != 'Typpo DCAA Client' )
{
	return;
}
*/

$display = "# You MAY NOT duplicate this list.\n".file_get_contents("incl/quest");

require_once('../auth/class.rc4crypt.php');
echo bin2hex(rc4crypt::encrypt($display,$useragent));

?>
