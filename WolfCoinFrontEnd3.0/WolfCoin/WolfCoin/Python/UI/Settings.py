# Team 03
# Settings.py
# This class gives the user the ability to change the user interface to a different color 

from UI.UserInfo import *

class SettingsTab(tk.Frame, UserInfoAndHelper):
  # default init of settings tab
  def __init__(self, master):
    super().__init__(master)
    # creating var to hold blue status in check variable
    self.blueStatus = tk.IntVar()
    # setting the label to change settings at top of pane
    tk.Label(self, text="Change Settings", font=('', 18, 'bold')).grid(row=0, column=0, sticky='w')
    # creating the check box button to switch from dark blue to nomral
    tk.Checkbutton(self, text="Dark Blue", command=self.setBlue, variable=self.blueStatus, onvalue=1, offvalue=0).grid(row=1, column=0, sticky='w')
    #setting pane separation
    for child in self.winfo_children():
      child.grid_configure(padx=12, pady=2)
  
  # this function executes when the checkbox is selected
  def setBlue(self):
    # if the button has been checked, true
    if self.blueStatus.get() == 1:
      # set background to dodger blue
      self.config(background="DodgerBlue2")
      self.bgcolor = "DodgerBlue2"
    # else if the button has not been checked
    elif self.blueStatus.get() == 0:
      # the background remains normal at white smoke
      self.config(background='white smoke')
      self.bgcolor = 'white smoke'
    
    # creating a child in the pane for the tab
    for child in self.winfo_children():
      child.config(bg=self.bgcolor)
    self.update()

    for child in self.winfo_children():
      child.grid_configure(padx=12, pady=2)