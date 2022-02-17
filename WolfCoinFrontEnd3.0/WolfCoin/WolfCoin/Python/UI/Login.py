# Team 03
# Login.py 
# This is the initial login screen of the application

import tkinter as tk
from tkinter import StringVar, ttk
import hashlib

# dictionary of user logins for testing
user_login_database = {
  'user' : hashlib.sha256("pass".encode('utf-8')).hexdigest(),
  'user2' : hashlib.sha256("pass2".encode('utf-8')).hexdigest(),
  'user3' : hashlib.sha256("pass3".encode('utf-8')).hexdigest()}

# this class is for the login of the application. once started from the terminal 
class Login():

  # default init of the login screen
  def __init__(self):
    self.failures = 0
    self.root = tk.Tk()
    # setting the root title of the application
    self.root.title("WolfCoin")
    self.root.grid_rowconfigure(0, weight=1)
    self.root.grid_columnconfigure(0, weight=1)
    credentialFrame = tk.Frame(self.root)
    self.uname = StringVar()
    self.pwd = StringVar()
    self.errorVar = StringVar()
    self.loggedIn = False
    self.credentials = str()

    # creating the label to display within the pane
    tk.Label(self.root, text="WolfCoin Login", font=('', 18, 'bold')).grid(row=0, column=0, sticky='EW', pady=8)
    errorLabel = tk.Label(self.root, textvariable=self.errorVar, fg='#ff0000')
    errorLabel.grid(row=1, column=0, sticky='EW')

    # creating the credential frame
    credentialFrame.grid(row=2, column=0, sticky='')\
    # creating username label and field to enter uname
    tk.Label(credentialFrame, text="Username").grid(row=0, column=0)
    tk.Entry(credentialFrame, width=20, textvariable=self.uname).grid(row=0, column=1)
    # creating password label and field to enter password
    tk.Label(credentialFrame, text="Password").grid(row=1, column=0)
    tk.Entry(credentialFrame, show='\u2022', width=20, textvariable=self.pwd).grid(row=1, column=1)
    # calling doLogin to check the credentials against the dictionary
    tk.Button(self.root, text="Login", command=self.doLogin, width=10).grid(row=3, column=0, sticky='', pady=8)

    self.root.bind('<Return>', self.doLogin)
    self.root.protocol("WM_DELETE_WINDOW", self.root.destroy)
    self.root.mainloop()

  # do login checks against the local password dictionary
  def doLogin(self, *args):
    print("Received login information:", self.uname.get(), hashlib.sha256(self.pwd.get().encode('utf-8')).hexdigest())
    # if credentials have been received successfully
    if self.checkLogin():
      self.errorVar.set('')
      self.closeAppOnSuccess()
    # login failed, after 3 failed attempts application will quit
    else:
      self.failures += 1
      self.errorVar.set("Username or password incorrect.")
      if self.failures > 3:
        self.root.destroy()
  
  # this is the helper function for doLogin that checks the dictionary
  def checkLogin(self):
    # if the credentials are within the dictionary
    if self.uname.get().lower() in user_login_database:
      # if the password matches in the dictionary return true
      if hashlib.sha256(self.pwd.get().encode('utf-8')).hexdigest() == user_login_database[self.uname.get().lower()]:
        print("Correct")
        self.credentials = self.uname.get().lower()
        self.uname.set('')
        self.pwd.set('')
        return True
      # else return false
      else:
        self.pwd.set('')
        return False
    # else the credentials are not within the dictionary
    else:
      self.pwd.set('')
      return False
  
  # close the application
  def closeAppOnSuccess(self):
    self.root.destroy()
    self.loggedIn = True

# debug:
# Uncomment this if NOT running with Main.py
#Login()