import { Link } from "react-router-dom";
import { FiArrowLeft } from "react-icons/fi";
import ProductTabs from "../components/products/ProductTabs";
import RelatedProducts from "../components/products/RelatedProducts";

import ProductImage from "../components/products/ProductImage";
import ProductDetailsInfo from "../components/products/ProductDetailsInfo";

function ProductDetails() {
  return (
    <>
      <section className="bg-gray-50 py-16">

        <div className="max-w-7xl mx-auto px-6">

          {/* Back Button */}

          <Link
            to="/products"
            className="inline-flex items-center gap-2 text-green-600 font-semibold hover:underline mb-10"
          >
            <FiArrowLeft />
            Back to Products
          </Link>

          <div className="grid lg:grid-cols-2 gap-20 items-center">

            <ProductImage />

            <ProductDetailsInfo />

          </div>

        </div>

      </section>

      <ProductTabs />

      <RelatedProducts />

    </>
  );
}

export default ProductDetails;