#! /usr/bin/env python
import sys
import pycurl
import json
import urllib2

def get_hello_info():

	values = {"Name":r"Test this service"}
	json_str = json.dumps(values)

	username = ""
	password = ""
	
	service_output = get_data("http://localhost:9200", "Hello", json_str, username, password)
	json_data = json.loads(service_output)
	print 'Result: ' + json_data['Result']
	

def get_data(base_url, service_name, post_data, username, thePassword):
	'''
	@param base_url the base url of the service.  It must not end with a / character.
	@param service_name the name of the service.  This is case sensitive.
	@param post_data the data to post.  Should already be encoded json using the json_encode function.
	@param username if basic authentication is being used.
	@param thePassword if basic authentication is being used..
	'''
	url = base_url + '/json/syncreply/' + service_name
	
	request = urllib2.Request(url, post_data)
	
	request.add_header('Content-Type', 'application/json')
	request.add_header("Accept", "application/json")
	request.add_header("Expect", "100-continue")
	# The user agent should be replaced with your applications
	request.add_header("User-Agent", "Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/30.0.1599.101 Safari/537.36")
	
	if username != "" and thePassword != "":
		passman = urllib2.HTTPPasswordMgrWithDefaultRealm()
		passman.add_password(None, url, username, thePassword)
		authhandler = urllib2.HTTPBasicAuthHandler(passman)
		opener = urllib2.build_opener(authhandler) 
		urllib2.install_opener(opener)

	
	result = urllib2.urlopen(request)
	response = result.read()
	result.close()
	return response


if __name__ == "__main__":
	get_hello_info()