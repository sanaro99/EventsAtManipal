CREATE TABLE CATEGORY (
	category_id int NOT NULL,
	category_name varchar(20) NOT NULL,
	PRIMARY KEY (category_name)
);

CREATE TABLE CCMEMBERS (
	member_id int NOT NULL,
	member_name varchar(30) NOT NULL,
	category_name varchar(20) NOT NULL,
	phone_num varchar(10) NOT NULL,
	password varchar(20) NOT NULL,
	PRIMARY KEY (member_id),
	FOREIGN KEY (category_name) REFERENCES CATEGORY(category_name)
);


CREATE TABLE EVENT (
	event_name varchar(20) NOT NULL,
	category_name varchar(20) NOT NULL,
	description varchar(100) NOT NULL,
	team_size int NOT NULL,
	PRIMARY KEY (event_name),
	FOREIGN KEY (category_name) REFERENCES CATEGORY(category_name)
);

CREATE TABLE TEAM (
	team_id int NOT NULL,
	event_name varchar(20) NOT NULL,
	PRIMARY KEY (team_id),
	FOREIGN KEY(event_name) REFERENCES EVENT(event_name)
);

CREATE TABLE WINNERS (
	event_name varchar(20) NOT NULL,
	winner_id int NOT NULL,
	runnerup_id int NOT NULL,
	winner_prize_money int,
	runnerup_prize_money int,
	PRIMARY KEY(event_name),
	FOREIGN KEY(event_name) REFERENCES EVENT(event_name),
	FOREIGN KEY (winner_id) REFERENCES TEAM(team_id),
	FOREIGN KEY (runnerup_id) REFERENCES TEAM(team_id)
);

CREATE TABLE EVENT_ROUND (
	event_name varchar(20) NOT NULL,
	round int NOT NULL,
	venue varchar(30) NOT NULL,
	start_time TIMESTAMP NOT NULL,
	end_time TIMESTAMP NOT NULL,
	PRIMARY KEY (event_name,round),
	FOREIGN KEY (event_name) REFERENCES EVENT(event_name)
);

CREATE TABLE PARTICIPANT (
	participant_id int NOT NULL,
	participant_name varchar(30) NOT NULL,
	arrival_date DATE NOT NULL,
	return_date DATE NOT NULL,
	hostel_block int NOT NULL,
	gender varchar(1) NOT NULL,
	college varchar(30) NOT NULL,
	password varchar(30) NOT NULL,
	PRIMARY KEY (participant_id),
	check (gender in ('M', 'F'))
);

CREATE TABLE TEAM_MEMBERS (
	team_id int NOT NULL,
	participant_id int NOT NULL,
	FOREIGN KEY (team_id) REFERENCES TEAM(team_id),
	FOREIGN KEY (participant_id) REFERENCES PARTICIPANT(participant_id)
);

CREATE TABLE EVENT_HEADS (
	head_id int NOT NULL,
	head_name varchar(30) NOT NULL,
	event_name varchar(20) NOT NULL,
	phone_num varchar(10) NOT NULL,
	password varchar(20) NOT NULL,
	PRIMARY KEY (head_id),
	FOREIGN KEY (event_name) REFERENCES EVENT(event_name)
);

CREATE TABLE VOLUNTEERS (
	volunteerID int NOT NULL,
	volunteer_name varchar(30) NOT NULL,
	category_name varchar(20),
	phone_num varchar(10) NOT NULL,
	PRIMARY KEY (volunteerID),
	FOREIGN KEY (category_name) REFERENCES CATEGORY(category_name)
);

CREATE TABLE QUALIFIED (
	event_name varchar(20) NOT NULL,
	round int NOT NULL,
	team_id int NOT NULL,
	FOREIGN KEY (event_name, round) REFERENCES EVENT_ROUND(event_name, round),
	FOREIGN KEY (team_id) REFERENCES TEAM(team_id)
);

CREATE TABLE JUDGES (
	judge_id int NOT NULL,
	judge_name varchar(30) NOT NULL,
	event_name varchar(20) NOT NULL,
	password varchar(20) NOT NULL,
	PRIMARY KEY (judge_id),
	FOREIGN KEY (event_name) REFERENCES EVENT(event_name)
);