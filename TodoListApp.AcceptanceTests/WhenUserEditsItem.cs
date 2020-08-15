﻿using System;
using NUnit.Framework;
using TodoListApp.AcceptanceTests.Pages;

namespace TodoListApp.AcceptanceTests
{
    public class WhenUserEditsItem : AcceptanceTestBase
    {
        private TodoListPage todoListPage;

        protected override void AdditionalSetup()
        {
            todoListPage = SignIn();
        }

        [Test]
        public void ItemIsDisplayedAsDone()
        {
            var description = "Item " + DateTime.Now.ToString("s");
            AssumeExistingItemWithDescription(description);

            var newDescription = "Updated " + DateTime.Now.AddSeconds(2).ToString("s");
            todoListPage.EditItemWithDescription(description)
                .Description(newDescription)
                .MarkAsDone()
                .Submit();

            var todoItem = todoListPage.GetItem(newDescription);
            Assert.IsNotNull(todoItem);
            Assert.That(todoItem.State, Is.EqualTo("Done"));
            Assert.That(todoItem.DateOfLastUpdate, Is.EqualTo(DateTime.Now).Within(TimeSpan.FromSeconds(3)));
        }
        
        private void AssumeExistingItemWithDescription(string description)
        {
            todoListPage.AddItem()
                .WithDescription(description)
                .Submit();
        }        
    }
}