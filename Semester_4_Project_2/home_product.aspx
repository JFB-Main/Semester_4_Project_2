<%@ Page Title="" Language="C#" MasterPageFile="~/HomeMaster.Master" AutoEventWireup="true" CodeBehind="home_product.aspx.cs" Inherits="Semester_4_Project_2.home_product" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="App_Themes\Project_Theme\styles\homepage-product.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <div class="container-fluid section-hero">
            <h1>
                Integrity, Efficiency, Honesty and Pragmatic
            </h1>
        </div>

            <div class="divider">
            <div class="divider-text">
                <div class="divider-lowopacity">
                    INTRO   
                </div>
                <p>
                    ▼ // SIGMA
                </p>
                <h3>
                    Intro
                </h3>
            </div>
            <div class="divider-line">
        </div>
        </div>

        <div class="section-intro">
            <div class="about-intro-vision">
                <div class="about-intro-vision-title">
                    <h3>
                        Our Vision
                    </h3>
                </div>
                <div class="about-intro-vision-display">
                    <p class="vision-display-textEdit1">
                        Creating a supply depot for 
                    </p>
                    <p class="vision-display-textEdit2">
                        billions people in 2030s.
                    </p>
                </div>
            </div>
            <div class="about-intro-lenght">
                <div class="about-intro-lenght-title">
                    <h3>
                        About Us
                    </h3>
                </div>
                <div class="about-intro-lenght-desc">
                    <p>
                        Welcome to our company, your trusted partner for efficient and reliable warehousing solutions. With our state-of-the-art facilities, we provide flexible storage options tailored to meet the unique needs of your business.
                    </p>
                    <p>
                        Whether you're managing high-volume inventory, seasonal surges, or specialized goods, we ensure seamless operations, real-time tracking, and secure handling. Our team of experts is committed to optimizing your logistics, helping you save time, reduce costs, and focus on what matters most—growing your business.
                    </p>
                    <p>
                        Experience unparalleled service with our company, where your storage and distribution needs are always in good hands.
                    </p>
                </div>
            </div>
            <div class="about-intro-philosophy">
                <div class="about-intro-philosophy-title">
                    <h3>
                        • Our Philosophy •
                    </h3>
                </div>
                <div class="about-intro-philosophy-desc">
                    <p>
                        Innovative | efficient | customer-driven warehousing solutions.
                    </p>
                </div>
            </div>
        </div>
        <hr />
        <div class="divider">
            <div class="divider-text">
                <div class="divider-lowopacity">
                    PRODUCTS
                </div>
                <p>
                    ▼ // SIGMA
                </p>
                <h3>
                    Products
                </h3>
            </div>
            <div class="divider-line">
            </div>
        </div>
        <div class="content-supplier">
            <p class="sup-desc">
                This comprehensive list comprises all the products carefully stored within the secure confines of our company warehouse system. Each item within our grasp undergoes stringent measures to uphold its pristine quality and ensure that it remains in optimal condition at all times. Our dedicated team meticulously monitors the inventory to guarantee that every product is accounted for and maintained to the highest standards.
            </p>
            <hr style="width: 50%; margin-left:auto; margin-right:auto;"/>
            <div class="sup-content">
                <div class="sup-content-search">
                    <div>
                        <div class="mb-3">
                            <label for="productNameForm" class="form-label">Product Name</label>
                            <input type="text" class="form-control" id="productNameForm" placeholder="Enter the product name">
                        </div>
                        <div class="mb-3">
                            <label for="supplierForm" class="form-label">Supplier Name</label>
                            <input type="text" class="form-control" id="supplierForm" placeholder="Enter the supplier name">
                        </div>
                    </div>
                    <div class="col-12">
                        <button type="submit" class="btn btn-primary button-black-design">Search</button>
                    </div> 
                </div>
                <div class="sup-content-table">
                     <table class="table table-hover table-striped table-products" style="outline: 1px solid #343434;>
                      <tr style="border-bottom:1px solid black;">
                        <th>Product Name</th>
                        <th>Description</th>
                      </tr>
                        <asp:Repeater ID="Repeater1" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td><%# Eval("stock_name") %></td>
                                    <td><%# Eval("description") %></td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </table>
                </div>
            </div>
        </div>
</asp:Content>
