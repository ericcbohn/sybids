USE sybids;
CREATE TABLE leg
(legId INT NOT NULL AUTO_INCREMENT,
dutyId INT NOT NULL,
legNum INT NOT NULL,
equipment CHAR(3) NOT NULL,
fleetCode CHAR(3) NOT NULL,
flightNum INT NOT NULL,
departureStation CHAR(3) NOT NULL,
arrivalStation CHAR(3) NOT NULL,
departureTime TIME NOT NULL,
arrivalTime TIME NOT NULL,
block TIME NOT NULL,
carrier CHAR(2) NOT NULL,
INDEX duty_ind (dutyId),
PRIMARY KEY (legId),
FOREIGN KEY (dutyId)
	REFERENCES duty(dutyId));