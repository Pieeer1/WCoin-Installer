# Team 03
# Blockchain.py
# This is the blockchain attributes file

# Blockchain module/classes file

import datetime
import hashlib
import random

# this class is for the individual blocks belonging to the blockchain
class Block:
  # each block has a number, data, next pointer, a nonce to guess, previous hash, and timestamp
  blockNo = 0
  data = None
  next = None
  nonce = 0
  previous_hash = 0x0
  timestamp = datetime.datetime.now()

  # upon initilization set these values
  def __init__(self, data):
    self.data = data
    self.hashVar = None
    if self.blockNo == 0:
      self.hash() # Genesis block

  # the block data gets hashed when stored on the chain
  def hash(self):
    h = hashlib.sha256()
    h.update(
    str(self.nonce).encode('utf-8') +
    str(self.data).encode('utf-8') +
    str(self.previous_hash).encode('utf-8') +
    str(self.timestamp).encode('utf-8') +
    str(self.blockNo).encode('utf-8')
    )
    self.hashVar = h.hexdigest()
    return self.hashVar
  
  # prints blockchain vars to terminal
  def __str__(self):
    return "Block Hash: " + str(self.hashVar) + "\nBlockNo: " + str(self.blockNo) + "\nBlock Data: " + str(self.data) + "\nHashes: " + str(self.nonce) + "\nPrev. Hash: " + str(self.previous_hash) + "\nTimestamp: " + str(self.timestamp) + "\n--------------"

# this class is the blockchain as a whole
class Blockchain:
  # diff set for the miners to guess
  difficulty_hash = 0x00FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF

  # Initial block creation
  block = Block("Genesis")
  dummy = head = block

  # Moving pointer
  def add(self, block):

    block.previous_hash = self.block.hashVar
    block.blockNo = self.block.blockNo + 1

    self.block.next = block
    self.block = self.block.next

  # Mining, incrementing nonce
  def mine(self, block):
    # passing block in and hashing it to base 16
    # then we are checking the block hash against the difficulty hash
    while int(int(block.hash(), 16) >= self.difficulty_hash):
      # increase the block guess by 1, until correct
      block.nonce += 1
    # once the correct nonce is guessed, block is added to the chain
    self.add(block)
    return block
