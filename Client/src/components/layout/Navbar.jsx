import { Link, NavLink } from "react-router-dom";
import {
  FiSearch,
  FiShoppingCart,
  FiUser,
  FiMenu,
} from "react-icons/fi";

function Navbar() {
  return (
    <header className="sticky top-0 z-50 bg-white shadow-md">
      <div className="max-w-7xl mx-auto px-6 h-20 flex items-center justify-between">

        {/* Logo */}
        <Link
          to="/"
          className="text-3xl font-extrabold text-green-600"
        >
          🌱 FreshMarket
        </Link>

        {/* Desktop Navigation */}
        <nav className="hidden md:flex items-center gap-8">

          <NavLink
            to="/"
            className={({ isActive }) =>
              `font-medium transition ${
                isActive
                  ? "text-green-600"
                  : "text-gray-700 hover:text-green-600"
              }`
            }
          >
            Home
          </NavLink>

          <NavLink
            to="/products"
            className={({ isActive }) =>
              `font-medium transition ${
                isActive
                  ? "text-green-600"
                  : "text-gray-700 hover:text-green-600"
              }`
            }
          >
            Products
          </NavLink>

        </nav>

        {/* Search */}
        <div className="hidden lg:flex items-center bg-gray-100 rounded-full px-4 py-2 w-96">

          <FiSearch className="text-gray-500 mr-2" />

          <input
            type="text"
            placeholder="Search fresh products..."
            className="bg-transparent outline-none flex-1"
          />

        </div>

        {/* Right Side */}
        <div className="flex items-center gap-5">

          {/* Cart */}

          <Link
            to="/cart"
            className="relative"
          >
            <FiShoppingCart size={24} />

            <span className="absolute -top-2 -right-2 bg-green-600 text-white text-xs rounded-full h-5 w-5 flex items-center justify-center">
              0
            </span>

          </Link>

          {/* Login */}

          <Link
            to="/login"
            className="hidden md:flex items-center gap-2 font-medium hover:text-green-600"
          >
            <FiUser />
            Login
          </Link>

          {/* Mobile */}

          <button className="md:hidden">
            <FiMenu size={28} />
          </button>

        </div>

      </div>
    </header>
  );
}

export default Navbar;