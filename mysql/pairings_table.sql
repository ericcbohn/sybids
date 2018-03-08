USE sybids;
CREATE TABLE pairing 
(pairingId INT NOT NULL AUTO_INCREMENT,
bidId INT NOT NULL,
pairingNum CHAR(5) BINARY NOT NULL UNIQUE, 
base CHAR(3) NOT NULL,
numDays INT NOT NULL, 
block TIME NOT NULL, 
credit TIME NOT NULL, 
numLandings INT NOT NULL,
numDeadheads INT NOT NULL,
tafb TIME NOT NULL,
PRIMARY KEY (pairingId),
FOREIGN KEY (bidId)
	REFERENCES bid(bidId));