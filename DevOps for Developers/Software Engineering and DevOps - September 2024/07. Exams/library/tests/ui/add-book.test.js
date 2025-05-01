const { test, expect } = require("@playwright/test");

test("Check add book page", async ({ page }) => {
  await page.goto("https://exam-prep-1-library.onrender.com/add-book");
  const form = await page.$("form");
  expect(form).toBeTruthy();
});
