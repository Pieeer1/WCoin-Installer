# Team 03
# Send.py
# This tab gives the user the functionality to send tokens to other accounts

from UI.UserInfo import *

# this class is the Send Tab, giving the user the ability to send tokens
class SendTab(tk.Frame, UserInfoAndHelper):
  
  # default init for 
  def __init__(self, master):
    super().__init__(master)
    self.receiver = tk.StringVar()
    self.amount = tk.StringVar()
    self.reason = tk.StringVar()

    # creating the label for send tokens
    tk.Label(self, text="Send Tokens", font=('', 18, 'bold')).grid(row=0, column=0, sticky='w')

    # the submit helper function
    def submitHelper():
      # creating temporary variables to store the reciever address, amount, and reason
      tempReceiver = self.receiver.get()
      tempAmount = self.amount.get()
      tempReason = self.reason.get()

      # error handling if empty
      if tempReceiver != '':
        try:
          tempAmount = float(tempAmount)
          if tempAmount > 0.0:
            if info.availableCoin-tempAmount > 0.0:
              self.receiver.set('')
              self.reason.set('')
              self.amount.set('')
              # temp data stored in json format
              tempData = {
                'from' : info.address,
                'to' : tempReceiver,
                'amount': tempAmount,
                'reason' : tempReason
              }
              # adding data to the chain
              info.availableCoin -= tempData['amount']
              info.addToChain(tempData)
            else:
              mb.showerror(title="WolfCoin", message="There are not enough tokens to perform this transaction.")
          else:
            mb.showerror(title="WolfCoin", message="The amount to send must be greater than zero.")
        except ValueError:
          mb.showerror(title="WolfCoin", message="The amount must be a positive number.")
      else:
        mb.showerror(title="WolfCoin", message="This is not a valid account address.")

    # creating the frame for user interaction
    recipientFrame = tk.Frame(self)
    recipientFrame.grid(row=1, column=0)
    # creating label for reciever address box
    tk.Label(recipientFrame, text="Receiver Address").grid(row=0, column=0)
    tk.Entry(recipientFrame, width=20, textvariable=self.receiver).grid(row=0, column=1)
    # creating label for amount entry field
    tk.Label(recipientFrame, text="Amount").grid(row=1, column=0)
    tk.Entry(recipientFrame, width=20, textvariable=self.amount).grid(row=1, column=1)
    # creating label for reason and entry field
    tk.Label(recipientFrame, text="Reason (optional)").grid(row=2, column=0)
    tk.Entry(recipientFrame, width=20, textvariable=self.reason).grid(row=2, column=1)
    # button to confirm transaction and add to the blockchain
    tk.Button(self, text="Send", width=10, command=submitHelper).grid(row=2, column=0, columnspan=2, sticky='')
    # returning to initial state after sending coins
    self.bind('<Return>', submitHelper)
    # creating the pane area
    for child in self.winfo_children():
      child.grid_configure(padx=12, pady=2)