# Team 03
# Account.py

from UI.UserInfo import *

# this class creates the Account Tab within the application. It has the ability to view the account
# address and how many tokens belong to that account.
class AccountTab(tk.Frame, UserInfoAndHelper):
  # default init of account tab
  def __init__(self, master):
    super().__init__(master)
    self.grid_columnconfigure(0, weight=1)
    addressFrame = tk.Frame(self)
    # setting the label at top of account page
    tk.Label(self, text="Account Overview", font=('', 18, 'bold')).grid(row=0, column=0, sticky='w')
    self.currentAvailableCoin = StringVar()
    # displaying the current balance for the user's account
    self.currentAvailableCoin.set(f"Current balance: {info.availableCoin} WC")

    # updates the currency for the user after transactions have occured
    def on_visibility(event=None):
      # the updated currency is called
      info.updateCurrency()
      # the current balance is refreshed and updated ton the server
      self.currentAvailableCoin.set(f"Current balance: {info.availableCoin} WC")
      self.update()

    # the field for the account address is set to the grid here
    addressFrame.grid(row=1, column=0)
    # creating a label for the account address to display
    tk.Label(addressFrame, text="Your account address is: ").grid(row=0, column=0)
    # the background to the account address is set to match the application
    accountAddress = tk.Text(addressFrame, height=1, borderwidth=0, background='white smoke')
    # we are inserting the address generated from UserInfo
    accountAddress.insert(1.0, info.address)
    accountAddress.configure(state="disabled")
    accountAddress.config(width=len(info.address))
    accountAddress.grid(row=0, column=1)
    # the available coins are displayed to the page along with an update button
    tk.Label(self, textvariable=self.currentAvailableCoin).grid(row=2, column=0)
    tk.Button(self, text="Update", width=10, command=on_visibility).grid(row=3, column=0)

    for child in self.winfo_children():
      child.grid_configure(padx=12, pady=2)
    
    self.bind("<Visibility>", on_visibility)