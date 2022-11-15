document.addEventListener('DOMContentLoaded', () => {
  openOrCloseCart();
})

function openOrCloseCart() {
  const cart = document.querySelector('#cart');
  const cartOverlay = document.querySelector('#cart-overlay');
  if(cart && cartOverlay) {
    let cartToggles = document.querySelectorAll('.cart-toggle');
    cartToggles.forEach(item => {
      item.addEventListener('click', event => {
        cart.classList.toggle('translate-x-0');
        cart.classList.toggle('translate-x-full');
        cartOverlay.classList.toggle('hidden');
      });
    });
  }
}
