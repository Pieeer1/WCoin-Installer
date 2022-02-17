# Team 03
# contains the class for user information
# This class passes all of the base attributes to the user logging in

import tkinter as tk
from tkinter.constants import END
import tkinter.messagebox as mb
import tkinter.filedialog as fd
from tkinter import StringVar, ttk
#from UI.Capture import Capturing
from Blockchain import Block, Blockchain
import os
import copy
import random
import datetime
import hashlib
import socket
import pickle
import base64

# user info and helper handles the user's information
class UserInfoAndHelper:
  # default user init
  def __init__(self):
    # the user is given the hash lib to hash blocks once mined
    h1 = hashlib.sha256()
    # updating the timestamp
    h1.update(str(datetime.datetime.now()).encode('utf-8'))
    # creating an address for the user
    self.address = str(h1.hexdigest())
    # setting the available coins randomly
    self.availableCoin = (random.randrange(1, 100) + ((random.randrange(2,9998) / random.randrange(1, 9999))/100.0))
    # creating the list to hold all chain hashes
    self.chainHashes = list()
    # defining the socket to connect to
    self.client_socket = socket.socket()
  
  # connecting to the WolfCoin Server
  def connect(self):
    # getting the host name with socket
    host = socket.gethostname()
    # searching for this port
    port = 5000
    # connecting to the socket
    self.client_socket = socket.socket()
    self.client_socket.connect((host, port))
  
  # sending a message from the application to the server
  def sendMessage(self, t, m=''):
    # we must first connect to the server
    self.connect()
    # hash the message using pickle dumps
    message = base64.b64encode(pickle.dumps([t, m]))
    # the client socket sends the message to the server
    self.client_socket.send(message)
    # try catch block, can only send 1024 bits at a time
    try:
      data = self.client_socket.recv(1024)
      self.client_socket.close()
      return pickle.loads(base64.b64decode(data))
    # when error occurs send message to user and exit
    except EOFError:
      mb.showerror(title="WolfCoin", message="Something went wrong. Good luck.")
      exit()

  # add a single block to the user's chain
  def addToChain_singleUser(self, data):
    # the result is set to the mined block data
    result = self.chain.mine(Block(data))
    # send a message to the user showing the hash and nonce
    mb.showinfo(title="WolfCoin", message=f"Mined block with hash {str(result.hashVar)[:10]}... with nonce of {str(result.nonce)}")
    try:
      # showing the previous hash to the user
      mb.showinfo(title="WolfCoin", message=f"Previous Hash: {str(result.previous_hash)[:10]}...")
    except:
      pass
    # once done, get the chain and show it
    self.getChain()
  
  # adding a block to the chain
  def addToChain(self, data):
    # the result is set to the message to be sent, or the block data
    result = self.sendMessage("Block", data)
    # send a message to the user once completed with block hash and nonce
    mb.showinfo(title="WolfCoin", message=f"Mined block with hash {str(result.hashVar)[:10]}... with nonce of {str(result.nonce)}")
    try:
      # try showing the previous hash, if not pass
      mb.showinfo(title="WolfCoin", message=f"Previous Hash: {str(result.previous_hash)[:10]}...")
    except:
      pass
  
  # get the chain and set to previous hashes 
  def getChain(self):
    # set chain hashes to a message for the server as request
    self.chainHashes = self.sendMessage("Request")
  
  # this updates the user's currency in their account
  def updateCurrency(self):
    self.availableCoin += float(self.sendMessage("Update", self.address))
  
  # get the chain for the single user's copy
  def getTheChain_singleUser(self):
    # creating a temporary list to swap the original chain over to
    tempList = list()
    # we are creating a deep copy of the temp pointer to the chain head
    tempPtr = copy.deepcopy(self.chain.head)
    # while the chain head is not empty
    while tempPtr != None:
      # append the temporary list we have created with hashes
      tempList.append(tempPtr.hashVar)
      # moving to the next block on the chain
      tempPtr = tempPtr.next
    # updating our chain hashes with the tempory list we created
    self.chainHashes = tempList

# this info is passed to all of the classes created as tabs
info = UserInfoAndHelper()