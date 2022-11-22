document.addEventListener('DOMContentLoaded', () => {
  openOrCloseCart();
  toggleMobileMenu();
})

function openOrCloseCart() {
  const cart = document.querySelector('#cart');
  const cartOverlay = document.querySelector('#cart-overlay');
  if(cart && cartOverlay) {
    let cartToggles = document.querySelectorAll('.cart-toggle');
    cartToggles.forEach(item => {
      item.addEventListener('click', () => {
        cart.classList.toggle('translate-x-0');
        cart.classList.toggle('translate-x-full');
        cartOverlay.classList.toggle('hidden');
      });
    });
  }
}

function toggleMobileMenu() {
  const menu = document.querySelector('#mobile-menu');
  const toggleButton = document.querySelector('#mobile-menu-toggle');
  if(menu && toggleButton) {
    toggleButton.addEventListener('click', () => {
      menu.classList.toggle('hidden');
    })
  }
}
