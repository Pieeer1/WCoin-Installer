# Team 03
# Main.py
# This is the main executable file for the application

from UI import Login, UserInterface
import sys

# create the login window pane and call user interface
loginWindow = Login.Login()
if loginWindow.loggedIn:
  UserInterface.Interface(loginWindow.credentials)
# else exit from the application
else:
  sys.exit()