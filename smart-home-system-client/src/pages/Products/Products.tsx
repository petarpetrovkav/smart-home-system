import './Products.scss'
import products from '../../assets/images/home_img/img-contact-hero-products_2x.jpg';
import dropdown_icon from '../../assets/images/dropdown_icon.png';
import Item from '../../components/Item/Item';
import data_product from "../../assets/images/new_collections";
import React from "react";

export default function Products() {
    return (
        <>
          <div className="shop-category">
              <img className="shop-category-banner" src={products} alt=""/>
              <div className="shop-category-indexSort">
                  <p>
                      <span>Showing 1-12 </span> out fo 36 products
                  </p>
                  <div className="shop-category-sort">
                      Sort by <img src={dropdown_icon} alt=""/>
                  </div>
              </div>
              <div className="shop-category-products">
                  {
                      data_product.map((item,index)=>{
                          return <Item item={{id: item.id, name: item.name, image: item.image, new_price: item.new_price, old_price: item.old_price}}/>
                  })}
              </div>
              <div className="shop-category-load-more">
                  Explore More
              </div>
          </div>
        </>);
}