﻿using coffeeshop;

var context = new ProductsContext();

context.Database.EnsureDeleted();
context.Database.EnsureCreated();

UserInterface.MainMenu();
