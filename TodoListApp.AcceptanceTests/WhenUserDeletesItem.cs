﻿using System;
using NUnit.Framework;
using TodoListApp.AcceptanceTests.Pages;

namespace TodoListApp.AcceptanceTests
{
    public class WhenUserDeletesItem : AcceptanceTestBase
    {
        private TodoListPage todoListPage;

        protected override void AdditionalSetup()
        {
            todoListPage = SignIn();
        }

        [Test]
        public void ItemsIsRemovedFromTodoList()
        {
            var currentCount = todoListPage.CountItems();
            var description = "Test item from " + DateTime.Now.ToString("s");
            AssumeExistingItemWithDescription(description);

            todoListPage.DeleteItem(description);

            Assert.That(todoListPage.CountItems(), Is.EqualTo(currentCount));
        }

        private void AssumeExistingItemWithDescription(string description)
        {
            todoListPage.AddItem()
                .WithDescription(description)
                .Submit();
        }
    }
}