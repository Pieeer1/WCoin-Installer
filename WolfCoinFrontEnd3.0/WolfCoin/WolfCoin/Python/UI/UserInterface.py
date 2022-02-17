# Team 03
# UserInterface.py
# This file sets the entire UserInterface for the application
from UI.UserInfo import *
from UI.Account import AccountTab
from UI.Send import SendTab
from UI.Chain import BlockchainTab
#from UI.Contracts import ContractsTab
from UI.Settings import SettingsTab

class Interface(UserInfoAndHelper):
  # default init for the tabs in WolfCoin
  def __init__(self, user="Testing me aren't you"):
    global defaultbg
    self.root = tk.Tk()
    self.root.title("WolfCoin")
    self.root.grid_rowconfigure(0, weight=1)
    self.root.grid_columnconfigure(0, weight=1)
    defaultbg = self.root.configure(background='white smoke')

    # creating a style to use for all tabs added to the menu
    tabStyle = ttk.Style()
    # creating a new theme with goldenrod buttons
    tabStyle.theme_create("Tab Style", parent="alt", settings={
      "TNotebook": {"configure": {"background" : 'goldenrod', 
      "foreground": "black"}},
      "TNotebook.Tab": {"configure": {"padding": [10],
      "background" : 'goldenrod',
      "foreground": "black"}}
    })
    # using the theme created as tab style
    tabStyle.theme_use("Tab Style")
    # setting the tkinter notebook root to this tab setting
    self.tabControl = ttk.Notebook(self.root)

    # creating the tab classes
    self.send = SendTab(self.tabControl)
    self.blockchain = BlockchainTab(self.tabControl)
    self.account = AccountTab(self.tabControl)
    #self.contracts = ContractsTab(self.tabControl)
    self.settings = SettingsTab(self.tabControl)
    
    # creating buttons and adding text to them
    self.tabControl.add(self.send, text="Send")
    self.tabControl.add(self.blockchain, text="Blockchain")
    self.tabControl.add(self.account, text="Account")
    #self.tabControl.add(self.contracts, text="Contracts")
    self.tabControl.add(self.settings, text="Settings")
    self.tabControl.grid(row=0, column=0, sticky='new')

    # at the bottom, show the user whon they are logged in as
    tk.Label(self.root, text=f"Logged in as {user}", bd=1, relief=tk.SUNKEN, anchor=tk.W).grid(sticky='sew')

    # function to close the application as event listener
    def closeMe():
      info.client_socket.close()
      self.root.destroy()
    # delete the window upon pressing x
    self.root.protocol("WM_DELETE_WINDOW", closeMe)
    self.root.mainloop()

# Uncomment this if NOT running with Main.py
#Interface()