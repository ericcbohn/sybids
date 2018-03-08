USE sybids;
CREATE TABLE duty
(dutyId INT NOT NULL AUTO_INCREMENT,
pairingId INT NOT NULL,
dutyDay INT NOT NULL,
numLegs INT NOT NULL,
dutyTime TIME NOT NULL,
block TIME NOT NULL,
credit TIME NOT NULL,
deadheadPay TIME NOT NULL,
rest TIME NOT NULL,
restType INT NOT NULL,
brief TIME NOT NULL,
debrief TIME NOT NULL,
INDEX paring_ind (pairingId),
PRIMARY KEY (dutyId),
FOREIGN KEY (pairingId)
	REFERENCES pairing(pairingId));