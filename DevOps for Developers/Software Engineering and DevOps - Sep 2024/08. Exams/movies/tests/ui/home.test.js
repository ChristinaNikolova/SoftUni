const { test, expect } = require("@playwright/test");

test("Check home page", async ({ page }) => {
  await page.goto("https://exam-prep-1-movies.onrender.com/");
  const heading = await page.$("h1");
  const text = await heading.textContent();
  expect(text).toContain("Movies Collection");
});
