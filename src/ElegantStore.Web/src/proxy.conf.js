const PROXY_CONFIG = [
  {
    context: [
      "/api/*",
    ],
    target: "http://localhost:7165",
    secure: false
  }
]

module.exports = PROXY_CONFIG;
