USE sybids;
CREATE TABLE bid
(bidId INT NOT NULL AUTO_INCREMENT,
bidDate DATE NOT NULL,
position CHAR(2) NOT NULL,
PRIMARY KEY (bidId),
INDEX bid_ind (bidDate));