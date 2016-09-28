import os
import sys
import time
import subprocess
import shutil

def run_cmd(cmd):
    print(cmd)
    err_code = os.system(cmd)
    if err_code != 0:
        print("ERROR: status code = {0}".format(err_code))
        sys.exit(1)

# Current path should be a checkout directory
cur_path = os.getcwd()
sc_bin_path = cur_path + "/sc/level1/bin/release"

# Checking that Starcounter binaries directory exists
if not os.path.exists(sc_bin_path):
  print("ERROR: Directory \"{0}\" containing Starcounter binaries does not exist".format(sc_bin_path))
  sys.exit(1)

# Setting StarcounterBin env var
print("Adding Starcounter to path")
os.environ["StarcounterBin"] = sc_bin_path
os.environ["Path"] = os.environ["Path"] + ";" + sc_bin_path

# Killing all Starcounter processes
run_cmd("staradmin kill all")

# Creating Starcounter server
srv_path = sc_bin_path + "/.srv"
if os.path.exists(srv_path):
  shutil.rmtree(srv_path)

run_cmd("star @@CreateRepo \"{0}\"".format(srv_path))

# Saving personal.xml file(TODO: add to CreateRepo)
personal_xml_path = sc_bin_path + "/configuration/personal.xml"
if not os.path.exists(personal_xml_path):
  print("ERROR: Personal XML file does not exist")
  sys.exit(1)

# Saving personal.xml file
text_file = open(personal_xml_path, "w")
text_file.write('<?xml version="1.0" encoding="UTF-8"?>')
text_file.write("<service><server-dir>{0}</server-dir></service>".format(srv_path + "/personal"))
text_file.close()

# Starting some Starcounter process
print("Starting async Starcounter processes")
sc_proc = subprocess.Popen(["scservice"])

# Build and run KitchenSink
run_cmd('build.bat')
run_cmd('test.bat')

# Killing all Starcounter processes
print("Killing Starcounter processes...")
err_code = os.system("staradmin kill all")
if err_code != 0:
  print("ERROR: Kill all returned an error code {0}".format(err_code))
  sys.exit(1)

# Printing end message
print("Build is finished!")
