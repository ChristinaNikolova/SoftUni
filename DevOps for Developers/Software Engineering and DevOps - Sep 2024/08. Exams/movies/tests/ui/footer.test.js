const { test, expect } = require("@playwright/test");

test("Check footer", async ({ page }) => {
  await page.goto("https://exam-prep-1-movies.onrender.com");
  const footer = await page.$("footer");
  const text = await footer.textContent();
  expect(text).toContain(
    "© 2023 - Software Engineering and DevOps exam preparation"
  );
});
