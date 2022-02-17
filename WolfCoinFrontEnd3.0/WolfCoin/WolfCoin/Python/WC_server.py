# Team 03
# WC Server.py
# This server hosts all updates being sent to the blockchain

import socket, pickle, base64, copy
from Blockchain import Block, Blockchain

# define the server program to connect to
def server_program():
    # the host must have a host name
    host = socket.gethostname()
    # this is the port the host has
    port = 5000
    # creating the server socket for clinets to connect to
    server_socket = socket.socket()
    server_socket.bind((host, port))
    # the server is listening
    server_socket.listen(10)
    # pending transactions get stored in a dictionary
    pendingTransactions = dict()
    # importing blockchain attributes
    b = Blockchain()

    # retriving transactions from the user
    def retrieveTransactions(a):
      try:
        return pendingTransactions.pop(a)
      except KeyError:
        return 0

    # get the chain from a users application by creating a deep copy
    def getTheChain():
      tempList = list()
      tempPtr = copy.deepcopy(b.head)
      while tempPtr != None:
        tempList.append(tempPtr.hashVar)
        tempPtr = tempPtr.next
      return tempList

    # accept a message being sent from client application
    def acceptMessage():
      conn, address = server_socket.accept()
      print("Connection from: " + str(address))
      while True:
        try:
          # can only recieve 1024 bits at a time
          data = conn.recv(1024)
          # endcode the data objects being passed with pickle dumps
          data_obj = pickle.loads(base64.b64decode(data))
          if not data:
              # if data is not received break
              break
          print("from connected user: " + str(data_obj))
          # if the data is a block store it
          if data_obj[0] == "Block":
            out = b.mine(Block(data_obj))
            try:
              # store the pending transactions
              pendingTransactions[(data_obj[1])["to"]] += (data_obj[1])["amount"]
            except KeyError:
              pendingTransactions[(data_obj[1])["to"]] = (data_obj[1])["amount"]
          # send the request back to the server, for the client to know
          elif data_obj[0] == "Request":
            out = getTheChain()
          # request an update from the server
          elif data_obj[0] == "Update":
            out = retrieveTransactions(data_obj[1])
          else:
            break
          # send the hashed data back
          conn.send(base64.b64encode(pickle.dumps(out)))
        # close at end of file error
        except EOFError:
          conn.close()
          break
        # close at connection reset error
        except ConnectionResetError:
          conn.close()
          break
    
    # while true accept this message
    while True:
      acceptMessage()

# run the server
if __name__ == '__main__':
    server_program()