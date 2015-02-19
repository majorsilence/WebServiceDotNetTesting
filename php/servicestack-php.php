<?php

get_hello_info();

function get_hello_info()
{
	$json_str = json_encode(array('Name' =>  'Test this service'));
	
	
	/*
	$username = "user";
	$password = "password";
	$cred = "{$username}:{$password}";
	*/
	// If you are connecting to a service that uses basic authentication 
	// you can use the code above to set the credentials.
	$cred = "";

	$json = post_data_curl("http://localhost:9200", "Hello", $json_str, $cred);
	echo 'Result: ' . $json->{'Result'} . "<br />";
}

/**
* Generic curl function to POST to a servicestack.net service.  This function
* will work with both HTTP and HTTPS but does not validate an HTTPS connection.
*
* @param string $base_url the base url of the service.  It must not end with a / character.
* @param string $service_name the name of the service.  This is case sensitive.
* @param json $post_data the data to post.  Should already be encoded json using the json_encode function.
* @param string $credentials the username and password to login to the webservice. A string in Format "Username:Password"
* @ return json
*/
function post_data_curl($base_url, $service_name, $post_data, $credentials)
{

	
	// Will create a string like "http://localhost:9200/servicestack/json/syncreply/Hello";
	$url = $base_url . '/json/syncreply/' . $service_name;
	$contentLength = strlen($post_data);
	
	$ch = curl_init();
	curl_setopt($ch, CURLOPT_URL, $url);
	
	// Override the default headers
	curl_setopt($ch, CURLOPT_HTTPHEADER, array('Content-Type: application/json', 'Accept: application/json', "Expect: 100-continue"));
	
	// 0 do not include header in output, 1 include header in output
	curl_setopt($process, CURLOPT_HEADER, 0);   
	
	// Set username and password
	if ($credentials != "")
	{
		curl_setopt($ch,CURLOPT_USERPWD, $credentials); 
	}
	
	curl_setopt($process, CURLOPT_TIMEOUT, 30); 
	
	// if you are not running with SSL or if you don't have valid SSL
	$verify_peer = false;
	curl_setopt($ch, CURLOPT_SSL_VERIFYPEER, $verify_peer);
	
	// Disable HOST (the site you are sending request to) SSL Verification,
	// if Host can have certificate which is invalid / expired / not signed by authorized CA.
	$verify_host = false;
	curl_setopt($ch, CURLOPT_SSL_VERIFYHOST, $verify_host);
	
	// Set the post variables
	curl_setopt($ch, CURLOPT_CUSTOMREQUEST, "POST");
	curl_setopt($ch, CURLOPT_POST, 1);
	curl_setopt($ch, CURLOPT_POSTFIELDS, $post_data);
	
	// Set so curl_exec returns the result instead of outputting it.
	curl_setopt($ch, CURLOPT_RETURNTRANSFER, true);

	
	// Get the response and close the channel.
	$response = curl_exec($ch);
	curl_close($ch);
	
	$json_obj = json_decode($response);
	return $json_obj;
}


function get_data_curl($base_url, $service_name, $query_string, $credentials)
{

	
	// Will create a string like "http://localhost:9200/servicestack/json/syncreply/Hello";
	$url = $base_url . '/json/syncreply/' . $query_string;
	
	$ch = curl_init();
	curl_setopt($ch, CURLOPT_URL, $url);
	
	// Override the default headers
	curl_setopt($ch, CURLOPT_HTTPHEADER, array('Content-Type: application/json', 'Accept: application/json', "Expect: 100-continue"));
	
	// 0 do not include header in output, 1 include header in output
	curl_setopt($process, CURLOPT_HEADER, 0);   
	
	// Set username and password
	if ($credentials != "")
	{
		curl_setopt($ch,CURLOPT_USERPWD, $credentials); 
	}
	
	curl_setopt($process, CURLOPT_TIMEOUT, 30); 
	
	// if you are not running with SSL or if you don't have valid SSL
	$verify_peer = false;
	curl_setopt($ch, CURLOPT_SSL_VERIFYPEER, $verify_peer);
	
	// Disable HOST (the site you are sending request to) SSL Verification,
	// if Host can have certificate which is invalid / expired / not signed by authorized CA.
	$verify_host = false;
	curl_setopt($ch, CURLOPT_SSL_VERIFYHOST, $verify_host);
	
	
	// Set so curl_exec returns the result instead of outputting it.
	curl_setopt($ch, CURLOPT_RETURNTRANSFER, true);

	
	// Get the response and close the channel.
	$response = curl_exec($ch);
	curl_close($ch);
	
	$json_obj = json_decode($response);
	return $json_obj;
}


function put_data_curl($base_url, $service_name, $post_data, $credentials)
{

	
	// Will create a string like "http://localhost:9200/servicestack/json/syncreply/Hello";
	$url = $base_url . '/json/syncreply/' . $service_name;
	
	
	$ch = curl_init();
	curl_setopt($ch, CURLOPT_URL, $url);
	
	// Override the default headers
	curl_setopt($ch, CURLOPT_HTTPHEADER, array('Content-Type: application/json', 'Accept: application/json', "Expect: 100-continue"));
	
	// 0 do not include header in output, 1 include header in output
	curl_setopt($process, CURLOPT_HEADER, 0);   
	
	// Set username and password
	if ($credentials != "")
	{
		curl_setopt($ch,CURLOPT_USERPWD, $credentials); 
	}
	
	curl_setopt($process, CURLOPT_TIMEOUT, 30); 
	
	// if you are not running with SSL or if you don't have valid SSL
	$verify_peer = false;
	curl_setopt($ch, CURLOPT_SSL_VERIFYPEER, $verify_peer);
	
	// Disable HOST (the site you are sending request to) SSL Verification,
	// if Host can have certificate which is invalid / expired / not signed by authorized CA.
	$verify_host = false;
	curl_setopt($ch, CURLOPT_SSL_VERIFYHOST, $verify_host);
	
	// Set the post variables
	curl_setopt($ch, CURLOPT_POST, 1);
	curl_setopt($ch, CURLOPT_CUSTOMREQUEST, "PUT");
	curl_setopt($ch, CURLOPT_POSTFIELDS, $post_data);
	
	// Set so curl_exec returns the result instead of outputting it.
	curl_setopt($ch, CURLOPT_RETURNTRANSFER, true);

	
	// Get the response and close the channel.
	$response = curl_exec($ch);
	curl_close($ch);
	
	$json_obj = json_decode($response);
	return $json_obj;
}



?>
