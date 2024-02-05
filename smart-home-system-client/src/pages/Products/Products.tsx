import './Products.scss'
import banner_products from '../../assets/images/home_img/img-contact-hero-products_2x.jpg';
import Item from '../../components/Item/Item';
import React, {useEffect, useState} from "react";
import ProductService from "../../services/product";
import IItem from "../../models/Interface/IItem";


export default function Products() {
    const [products, setProducts] = useState<IItem[]>([]);


    useEffect(() => {
        getProducts();
    }, []);

    const getProducts = async () => {
        const data = await ProductService.getAllProducts();
        setProducts(data);
    }

    return (
        <>
          <div className="shop-category">
              <img className="shop-category-banner" src={banner_products} alt=""/>
              <div className="shop-category-products">
                  {
                     products.map((product,index)=>{
                          return <Item item={{productId: product.productId, productName: product.productName, imageUrl: product.imageUrl, price: product.price, productCategory: product.productCategory, productCategoryId: product.productCategoryId, description: product.description, stockQuantity: product.stockQuantity}}/>
                      })
                  }
              </div>
          </div>
        </>);
}