--Display all orders with more than 2000 value.
--Display order id and corresponding total.

select orderid, sum(price * quantity) as Total from sales.orderdetails group by orderid having sum(price * quantity) > 2000;

-- display all products costing more than 1000 
-- per unit
select * from Purchasing.Deliveries;
select productid, count(quantity) as "Total units delivered" from purchasing.Deliveries where price > 1000 group by productid having sum(quantity) >= 10;

-- display products that are delivered between oct. 1, 2016 with total units delivered being 10
-- or more units during the time period.

select productid, sum(quantity) as "Total Quantity",
avg(price) as "Average price" 
from purchasing.Deliveries
where cast(deliverydate as date) between '20161001' and '20161010'
group by productid
having sum(quantity) >= 10
order by sum(quantity) desc;


-- display orders that contain product id 1
-- show order id

select orderid from sales.orderdetails where productid = 1;

-- display customers who placed the order id 1, 2, 6

select distinct customerid from sales.orders where orderid in (1, 2, 6); 

-- display customers whose order contains productid1

select distinct customerid from sales.orders where orderid in 
(select orderid from sales.orderdetails where productid = 1); 