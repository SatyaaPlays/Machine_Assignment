create table Players(
player_id int Primary Key generated always as Identity,
player_name varchar(50),
email varchar(50),
registration_date date
);

insert into Players(player_name, email, registration_date) VALUES('Aakash', 'aakash@gmail.com','2023-04-24'),
('Abhishek','abhishek@gmail.com','2023-03-22'),
('Ananya','ananya@gmail.com','2023-02-22'),
('Anaya','anaya@gmail.com','2023-01-22'),
('Raunak','raunak@gmail.com','2023-04-22'),
('Rishabh','rishabh@gmail.com','2023-05-22'),
('Shubham','shubham@gmail.com','2022-03-22'),
('Suman','suman@gmail.com','2021-03-22'),
('Sashank','sashank@gmail.com','2020-03-22'),
('Smriti','smriti@gmail.com','2019-03-22'),
('Sai','sai@gmail.com','2023-01-11'),
('Sundar','sundar@gmail.com','2023-02-19'),
('Harsh','harsh@gmail.com','2022-09-22');

select * from Players;

create table Games(
game_id int Primary Key generated always as Identity,
game_name varchar(50),
game_category varchar(50)
);

insert into Games(game_name, game_category) values('GTA V', 'Action'),
('Red Dead Redemption 3', 'Adventure'),
('Mad Max', 'Action'),
('Unchartered', 'Adventure'),
('Forza', 'Racing'),
('Cricket22', 'Video Game'),
('Avengers', 'Action'),
('Ghost of Tsusima', 'Action');
select * from Games;


create table Scores(
score_id int Primary Key generated always as identity,
player_id int,
Foreign Key(player_id)
references Players(player_id),
game_id int,
Foreign Key(game_id)
references Games(game_id),
score int,
score_date date
);

insert into Scores(player_id, game_id, score, score_date) values(1,8,4000,'2023-06-20'),
(1,1,50,'2023-05-21'),
(2,2,4000,'2023-04-20'),
(3,3,400,'2023-03-20'),
(4,6,2000,'2023-01-20'),
(5,8,600,'2023-06-20'),
(6,8,3000,'2023-06-20'),
(7,2,600,'2023-06-20'),
(8,2,400,'2023-06-20'),
(9,2,500,'2023-06-20'),
(10,4,900,'2023-06-20');
select * from Scores;


-- Queries
----------------------
-- Write  query to display the top 10 players with the highest scores for a specific game.

select player.player_name, score.score
from players player
join Scores score on score.player_id = player.player_id
where score.game_id = 8
order by score.score desc
limit 10;

-- Write a query to find the average score for each game category.

select game.game_category, avg(score.score)::Numeric(10,2)
from Games game
join scores score on score.game_id = game.game_id
group by game.game_category

-- Write a query to calculate the player's highest score for each game they have played.

select player.player_name, game.game_name, max(score.score) as HighestScore
from players player
join Scores score on score.player_id = player.player_id
join Games game on game.game_id = score.game_id
group by player.player_name, game.game_name;

-- Write a query to determine the overall ranking of a specific player based on their total score across all games.

select player.player_name, sum(score.score) as TotalScore 
from players player
join Scores score on score.player_id = player.player_id
where player.player_id = 1
group by player.player_name

-- Write a query to find the players who have achieved a score higher than the average score for a specific game.

SELECT player.player_name, score.score
FROM Players player
JOIN Scores score ON player.player_id = score.player_id
JOIN Games game ON score.game_id = game.game_id
WHERE game.game_name = 'Ghost of Tsusima'
  AND score.score > (
    SELECT AVG(score)
    FROM Scores
    WHERE game_id = (
      SELECT game_id
      FROM Games
      WHERE game_name = 'Ghost of Tsusima'
    )
  );

-- Write a query to update a player's score for a specific game.

UPDATE Scores
SET score = 10000
WHERE player_id = 1
  AND game_id = (
    SELECT game_id
    FROM Games
    WHERE game_name = 'Ghost of Tsusima'
  );
  
-- Write a query to delete a player's score entry from the database.
DELETE FROM Scores
WHERE player_id = 2
  AND game_id = (
    SELECT game_id
    FROM Games
    WHERE game_name = 'Red Dead Redemption 3'
  );
  select * from Scores