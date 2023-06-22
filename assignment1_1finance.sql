create table users(
user_id int Primary Key,
username varchar(50),
email varchar(50),
join_date date
);

insert into users values(1, 'Aakash','aakash@gmail.com','2023-03-22'),
(2, 'Abhishek','abhishek@gmail.com','2023-03-22'),
(3, 'Ananya','ananya@gmail.com','2023-02-22'),
(4, 'Anaya','anaya@gmail.com','2023-01-22'),
(5, 'Raunak','raunak@gmail.com','2023-04-22'),
(6, 'Rishabh','rishabh@gmail.com','2023-05-22'),
(7, 'Shubham','shubham@gmail.com','2022-03-22'),
(8, 'Suman','suman@gmail.com','2021-03-22'),
(9, 'Sashank','sashank@gmail.com','2020-03-22'),
(10, 'Smriti','smriti@gmail.com','2019-03-22'),
(11, 'Sai','sai@gmail.com','2023-01-11'),
(12, 'Sundar','sundar@gmail.com','2023-02-19'),
(13, 'Harsh','harsh@gmail.com','2022-09-22')
select * from users;




create table Posts(
post_id int Primary Key GENERATED ALWAYS AS IDENTITY,
user_id int,
CONSTRAINT fk_users
FOREIGN KEY(user_id) 
REFERENCES users(user_id),
-- user_id int Foreign Key references users(user_id),
post_content varchar(100),
post_date date,
likes int,
comments int
);

insert into posts(user_id, post_content, post_date,likes,comments) values(1,'flowerimg','2023-04-22',2200,5),
(1,'sunshine','2023-05-22',2200,9),
(2,'smellofsand','2023-04-22',2200,24),
(2,'rain','2023-01-22',2200,109),
(2,'flowerimg','2023-06-22',2200,11),
(2,'fight','2023-05-22',2200,110),
(5,'lord','2023-04-22',2200,2500),
(6,'river','2023-04-22',2200,22),
(6,'rain','2023-03-22',2200,230),
(12,'flowerimg','2023-04-22',2200,1000);

select * from posts;


create table Likes(
like_id int Primary Key GENERATED ALWAYS AS IDENTITY,
user_id int,
Foreign Key(user_id)
references users(user_id),
post_id int ,
Foreign Key(post_id)
references posts(post_id)
);

insert into Likes (user_id, post_id) values(1,1),
(1,2),
(2,1),
(2,3),
(2,2),
(5,5),
(2,6),
(4,2),
(6,9),
(12,10)

select * from Likes;



create table Comments(
comment_id int Primary Key generated always as identity,
user_id int,
Foreign Key(user_id)
references users(user_id),
post_id int ,
Foreign Key(post_id)
references posts(post_id),
comment_content varchar(100),
comment_date date
)

insert into comments(user_id, post_id, comment_content,comment_date) values(1,1,'Beautiful flower','2023-04-22'),
(1,2,'Beautiful nature','2023-05-22'),
(2,1,'Beautiful nature','2023-04-22'),
(2,3,'Beautiful rain','2023-01-22'),
(2,2,'Beautiful flower','2023-06-22'),
(5,5,'Over Power','2023-05-22'),
(2,6,'Hail to God','2023-04-22'),
(4,2,'Beauty of nature','2023-04-22'),
(6,9,'Beautiful rain','2023-03-22'),
(12,10,'Beautiful flower','2023-04-22');

select * from comments


-- Queries
-----------------------------

-- Write SQL queries to retrieve the top 10 users with the highest number of posts.

select usr.username, count(post.post_id) as user_postCount from users usr
join Posts post on usr.user_id = post.user_id
group by usr.username
order by user_postCount desc
limit 10;

-- Write a query to find the average number of likes and comments per post.

select avg(post.likes)::NUMERIC(10,2) as Likes, avg(post.comments)::NUMERIC(10,2) as Comments
from Posts post;

-- Write a query to identify the users who have liked their own posts.

select distinct usr.username
from users usr
join Likes li on li.user_id = usr.user_id
join Posts post on post.user_id = usr.user_id
where usr.user_id = post.user_id;

-- Write a query to calculate the total number of likes and comments for each user.

select usr.username, sum(post.likes) as TotalLikes, sum(post.comments) as TotalComments from Users usr
join Posts post on post.user_id = usr.user_id
group by usr.username;

-- Write a query to find the most active day of the week in terms of user engagement (likes and comments).

select TO_CHAR(post.post_date,'DAY') as Daywise_Engagement, sum(post.likes + post.comments) as MostUserEngagement
FROM Posts post
group by Daywise_Engagement
order by MostUserEngagement 
limit 1;

-- Write a query to retrieve the top 5 posts with the highest number of comments, including the post content and the number of comments.

select post.post_content, post.comments
from posts post
order by post.comments desc
limit 5;
-- Write a query to find the users who have not made any posts.

select usr.username
from users usr
left join Posts post on post.user_id = usr.user_id
where post.post_id is null;

-- Write a query to calculate the average number of likes and comments per user.

select usr.username, avg(post.likes)::NUMERIC(10,2) as AverageLikes, avg(post.comments)::NUMERIC(10,2) as AverageComments from Users usr
join Posts post on post.user_id = usr.user_id
group by usr.username;

-- Write a query to identify the users who have posted on consecutive days, along with the date and content of their first and last posts.

select usr.username, min(post.post_date) as firstPostDate, max(post.post_date) as LastPostDate,
min(post.post_content) as firstPostContent, max(post.post_content) as LastrPostContent
from users usr
join Posts post on post.user_id = usr.user_id
group by usr.username;




