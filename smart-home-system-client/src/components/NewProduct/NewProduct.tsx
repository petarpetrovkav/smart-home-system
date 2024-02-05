import React from "react";
import IItem from '../../models/Interface/IItem';
import './NewProduct.scss';
/*import data_product from "../../assets/images/data";*/
import data_product from "../../assets/images/new_collections";
import Item from "../Item/Item";

export default function NewProduct() {
    return (
        <>
            <div className="new-product">
                <div className="products">
                    <h1>NEW PRODUCTS</h1>
                    <hr/>
                    <div className="collections">      {/*new-products*/}
                        {
                            data_product.map((item,index)=>{
                            return <Item item={{id: item.id, name: item.name, image: item.image, new_price: item.new_price, old_price: item.old_price}}/>
                        })}
                    </div>
                </div>
            </div>
        </>);
}