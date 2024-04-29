import './Products.scss'
import banner_products from '../../assets/images/home_img/img-contact-hero-products_2x.jpg';
import smart_home_hover from '../../assets/images/home_img/smart-home-hover.svg';
import smart_heating_hover from '../../assets/images/home_img/smart-heating-hover.svg';
import ev_charging_hover from '../../assets/images/home_img/ev-charging-hover.svg';
import Item from '../../components/Item/Item';
import React, {useEffect, useRef, useState} from "react";
import ProductService from "../../services/product";
import { useDispatch, useSelector } from 'react-redux';
import { getAll } from '../../store/productsSlice.js';
import productsReducer from "../../store/productsSlice";


export default function Products() {
    const products = useSelector(state => state.products);
    const dispatch = useDispatch();

    useEffect(() => {
        if(!products.length)
           getProducts()
    }, []);

    const getProducts = async () => {
        const data = await ProductService.getAllProducts();
        dispatch(getAll(data));
    }

    return (
        <>
            <div className="new-product">
                <div className="products">
                  <img className="shop-category-banner" src={banner_products} alt=""/>
                {/*    <div className="category-icon">
                        <div className="category-container">
                            <img onClick={() => selectCategoryRef.current = 'smart-home'} src={smart_home_hover} alt=""/>
                        </div>
                        <div className="category-container">
                            <img onClick={() => selectCategoryRef.current = 'smart-heating'} src={smart_heating_hover} alt=""/>
                        </div>
                        <div className="category-container">
                            <img onClick={() => selectCategoryRef.current = 'ev-charging'} src={ev_charging_hover} alt=""/>
                        </div>
                    </div>*/}
                  <div className="collections">
                      {
                         products.map((product,index)=>{
                              return <Item key={product.productId} item={{productId: product.productId, productName: product.productName, imageUrl: product.imageUrl, price: product.price, productCategory: product.productCategory, productCategoryId: product.productCategoryId, description: product.description, stockQuantity: product.stockQuantity}}/>
                          })
                      }
                  </div>
                </div>
          </div>
        </>);
}