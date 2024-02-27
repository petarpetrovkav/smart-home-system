import React, {useEffect, useState} from "react";
import './NewProduct.scss';
import ProductService from "../../services/product";

import Item from "../Item/Item";

export default function NewProduct() {

    const [products, setProducts] = useState([]);


    useEffect(() => {
        getProducts();
    }, []);

    const getProducts = async () => {
        const data = await ProductService.getAllProducts();
        console.log(data);
        setProducts(data);
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