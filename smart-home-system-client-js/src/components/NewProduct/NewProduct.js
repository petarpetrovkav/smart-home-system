import './NewProduct.scss';
import Item from "../Item/Item";
import React, {useEffect, useState} from "react";
import ProductService from "../../services/product";
import { useDispatch, useSelector } from 'react-redux';
import { getAll } from '../../store/productsSlice.js';


export default function NewProduct() {

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
                    <h1>NEW PRODUCTS</h1>
                    <hr/>
                    <div className="collections">      {/*new-products*/}
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