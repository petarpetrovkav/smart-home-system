import React from "react";
import IItem from '../../models/Interface/IItem';
import './Item.scss';

export default function Item(props: {item: IItem}) {
    return (
        <>
            <div className='item'>
                <img src={props.item.image} alt="" className='img'/>
                <p>{props.item.name}</p>
                <div className="item-prices">
                    <div className="item-price">
                        ${props.item.new_price}
                    </div>
                </div>
            </div>
        </>);
}