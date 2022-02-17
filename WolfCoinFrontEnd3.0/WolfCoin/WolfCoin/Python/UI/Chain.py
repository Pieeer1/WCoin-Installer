# Team 03
# Chain.py

from UI.UserInfo import *

# This class creates a tab for the blockchain within the desktop application. It allows
# the user to view the current state of the blockchain, giving the option to update
class BlockchainTab(tk.Frame, UserInfoAndHelper):
  
  # default init for the tab, setting values to default
  def __init__(self, master):
    super().__init__(master)
    self.currentHash = 0
    self.leftLabel = StringVar()
    self.leftHash = StringVar()
    self.centerLabel = StringVar()
    self.centerHash = StringVar()
    self.rightLabel = StringVar()
    self.rightHash = StringVar()

    self.leftLabel.set('')
    self.centerLabel.set('')
    self.rightLabel.set('')
    self.leftHash.set('')
    self.centerHash.set('')
    self.rightHash.set('')

    # this is the label that shows at the top of the page
    tk.Label(self, text="View Blocks", font=('', 18, 'bold')).grid(row=0, column=0, sticky='w')

    # this function returns the state of the blockchain to the application
    def setLabelState(t, s, i):
      labelText = ''
      hashText = ''
      if (s-i) > s:
        pass
      elif s > 0:
        labelText = f"Block {s-i}"
        hashText = f"{str(info.chainHashes[s-i])[:10]}..."

      t[0].set(labelText)
      t[1].set(hashText)

    # the labels for each block get set
    def setLabel():
      i = self.currentHash
      blockIndex = len(info.chainHashes)-1
      setLabelState([self.leftLabel, self.leftHash], blockIndex, i+1)
      setLabelState([self.centerLabel, self.centerHash], blockIndex, i)
      setLabelState([self.rightLabel, self.rightHash], blockIndex, i-1)

    # moves the block viewing pane left
    def moveLeft():
      if len(info.chainHashes)-2-self.currentHash > 0:
        self.currentHash += 1
        setLabel()

    # moves the block viewing pane right
    def moveRight():
      if self.currentHash > 0:
        self.currentHash -= 1
        setLabel()

    # sets the label
    setLabel()

    # setting the frame to tkinter and creating a grid
    blockchainFrame = tk.Frame(self)
    blockchainFrame.grid(row=1, column=0)
    # creating labels for each label within the viewing pane
    tk.Label(blockchainFrame, textvariable=self.leftLabel, font=('', 12, 'bold')).grid(row=0, column=0)
    tk.Label(blockchainFrame, textvariable=self.leftHash).grid(row=1, column=0)
    tk.Label(blockchainFrame, textvariable=self.centerLabel, font=('', 12, 'bold')).grid(row=0, column=1)
    tk.Label(blockchainFrame, textvariable=self.centerHash).grid(row=1, column=1)
    tk.Label(blockchainFrame, textvariable=self.rightLabel, font=('', 12, 'bold')).grid(row=0, column=2)
    tk.Label(blockchainFrame, textvariable=self.rightHash).grid(row=1, column=2)
    # these buttons move the pane from left to right to view 3 blocks at a time
    tk.Button(blockchainFrame, text="<", command=moveLeft).grid(row=2, column=0, sticky='w')
    tk.Button(blockchainFrame, text=">", command=moveRight).grid(row=2, column=2, sticky='e')

    # getting the chain to view
    def on_visibility(event=None):
      info.getChain()
      setLabel()
      self.update()

    # refresh button to get the newest copy of the chain from the WolfCoin server
    tk.Button(self, text="Refresh", width=10, command=on_visibility).grid(row=2, column=0)

    # configuring the grid confinements
    for child in self.winfo_children():
      child.grid_configure(padx=12, pady=2)

    # configuring frame components
    for child in blockchainFrame.winfo_children():
      child.grid_configure(padx=12, pady=2)

    self.bind("<Visibility>", on_visibility)
