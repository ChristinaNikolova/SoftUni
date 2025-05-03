const { test, expect } = require("@playwright/test");

test("Check boardgames page", async ({ page }) => {
  await page.goto("https://exam-prep-1-boardgames.onrender.com/boardgames");
  const list = await page.$("ul");
  expect(list).toBeTruthy();
});
