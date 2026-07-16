import CartItem from "../components/cart/CartItem";
import CartSummary from "../components/cart/CartSummary";

function Cart() {
  return (
    <section className="bg-gray-50 min-h-screen py-20">

      <div className="max-w-7xl mx-auto px-6">

        <h1 className="text-5xl font-bold mb-12">
          Shopping Cart
        </h1>

        <div className="grid lg:grid-cols-3 gap-10">

          {/* Left */}

          <div className="lg:col-span-2 space-y-6">

            <CartItem />
            <CartItem />
            <CartItem />

          </div>

          {/* Right */}

          <CartSummary />

        </div>

      </div>

    </section>
  );
}

export default Cart;