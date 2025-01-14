﻿using NT_Project.Models;
using NT_Project.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace NT_Project.Controllers
{
    public class Logic : Controller
    {
        private ApplicationDbContext _Context { get; set; }
        private int LastComment ;
        private int LastPost;
        public Logic()
        {
            _Context = new ApplicationDbContext();
            LastComment = _Context.Comments.Count()+1;
            LastPost = _Context.Posts.Count() + 1;
        }
        public ApplicationUser GetUser(string id)
        {
            return _Context.Users.Find(id);
        }
        public List<RelationsModel> GetRelations(string id)
        {
            var user = _Context.Users.Find(id);

            var firstRelations = user.FirstRelationships.ToList();
            var secondRelations = user.SecondRelationships.ToList();
            var ret = new List<RelationsModel>();

            foreach (var friend in firstRelations)
            {
                ret.Add(new RelationsModel { User = friend.Second, Type = friend.type });
            }
            foreach (var friend in secondRelations)
            {
                ret.Add(new RelationsModel { User = friend.First, Type = friend.type * -1 });
            }
            return ret;
        }
        public List<ApplicationUser> GetRelatedUsers(string id, int? type)
        {
            var relatedUsers = GetRelations(id);
            var friends = new List<ApplicationUser>();
            foreach (var item in relatedUsers)
            {
                if (item.Type == type || type == null) friends.Add(item.User);
            }

            return friends;
        }

        public List<ApplicationUser> AllUsers(string id)
        {
            return _Context.Users.Where(user => user.Id != id).ToList();
        }
        public List<ApplicationUser> NotRelated(string id)
        {
            var related = GetRelatedUsers(id, null);
            var all = AllUsers(id);
            var ret = new List<ApplicationUser>();
            foreach (var item in all)
            {
                if (related.Contains(item) == false) ret.Add(item);
            }
            return ret;
        }
        public List<Post> GetFriendsPosts(string id)
        {
            var friends = GetRelatedUsers(id, 0);
            var posts = new List<Post>();
            foreach (var item in friends)
            {
                posts.AddRange(item.Posts.ToList());
            }

            var ret = ShuffleList(posts);
            return ret;
        }
        public bool AddRelation(string first, string second, int? type)
        {
            if (String.Compare(first, second) == 1)
            {
                string tmp = first;
                first = second;
                second = tmp;
                type = -type;
            }
            if (type == null)
            {
                var tmp = _Context.Relationships.Find(first, second);

                if (tmp == null)
                    return false;

                _Context.Relationships.Remove(tmp);
            }
            else
            {
                var rel = _Context.Relationships.Find(first, second);
                if (rel == null)
                    _Context.Relationships.Add(new Relationship() { FirstId = first, SecondId = second, type = (int)type });
                else
                    rel.type = (int)type;
            }
            _Context.SaveChanges();
            return true;
        }
        public List<Interaction> GetInteractions(string id)
        {
            var currPost = _Context.Posts.Find(id);
            var res = new List<Interaction>();
            if (currPost != null)
            {
                res = currPost.Interactions.ToList();
            }
            return res;
        }
        public List<ApplicationUser> SearchAccount(string required, string id)
        {
            return NotRelated(id)?.Where(user =>
                (user.FirstName.Contains(required) || user.LastName.Contains(required)) ||
                user.PhoneNumber.Contains(required) || user.Email.Contains(required)).ToList();
        }
        public List<E> ShuffleList<E>(List<E> inputList)
        {
            var randomList = new List<E>();

            var r = new Random();
            while (inputList.Count > 0)
            {
                var randomIndex = r.Next(0, inputList.Count);
                randomList.Add(inputList[randomIndex]); //add it to the new, random list
                inputList.RemoveAt(randomIndex); //remove to avoid duplicates
            }

            return randomList; //return the new random list
        }

        public bool AddInteraction(string userId, string PostId, int type)
        {
            if (_Context.Interactions.Find(PostId, userId) != null) return false;
            Interaction ins = new Interaction
            {
                ApplicationUser = _Context.Users.Find(userId),
                ActionType = type,
                ApplicationUserId = userId,
                Post = _Context.Posts.Find(PostId),
                PostId = PostId
            };
            _Context.Interactions.Add(ins);
            _Context.SaveChanges();
            return true;
        }

        public bool RemoveInteraction(string userId, string PostId, int type)
        {
            var ins = _Context.Interactions.Find(PostId, userId);
            if (ins == null) return false;
            _Context.Interactions.Remove(ins);
            _Context.SaveChanges();
            return true;
        }

        public bool AddComment(string userId, string PostId, string text, string photo)
        {
            Comment ins = new Comment
            {
                ApplicationUser = _Context.Users.Find(userId),
                ApplicationUserId = userId,
                Post = _Context.Posts.Find(PostId),
                PostId = PostId,
                ContentPath = photo,
                Text = text,
                CommentId = LastComment++.ToString()
            };
            _Context.Comments.Add(ins);
            _Context.SaveChanges();




            return true;
        }

        public bool AddPost(string userId, string text, string photo)
        {
            Post ins = new Post
            {
                ApplicationUser = _Context.Users.Find(userId),
                ApplicationUserId = userId,
                ContentPath = photo,
                Text = text,
                PostId = LastPost++.ToString()

            };
            _Context.Posts.Add(ins);
            _Context.SaveChanges();
            return true;
        }

        public Post GetPost(string id)
        {
            return _Context.Posts.Find(id);
        }
        protected override void Dispose(bool disposing)
        {
            _Context.Dispose();
            base.Dispose(disposing);
        }
    }
}