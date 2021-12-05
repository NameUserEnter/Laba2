<?xml version = "1.0"?>
<xsl:stylesheet
        xmlns:xsl ="http://www.w3.org/1999/XSL/Transform" version ="1.0">
	<xsl:output method = "html"/>
	<xsl:template match = "StudentsSuccess">
		<html>
			<body>
				<table border = "1" width ="1200">
					<TR>
						<th>Name</th>
						<th>Faculty</th>
						<th>Department</th>
						<th>AcademicDisciplines</th>
						<th>StudentPerformance</th>
					</TR>
					<xsl:for-each select= "//StudentSuccess">
						<tr>
							<td>
								<xsl:value-of select= "@Name"/>
							</td>
							<td>
								<xsl:value-of select= "@Faculty"/>
							</td>
							<td>
								<xsl:value-of select= "@Department"/>
							</td>
							<td>
								<xsl:value-of select= "@AcademicDisciplines"/>
							</td>
							<td>
								<xsl:value-of select= "@StudentPerformance"/>
							</td>
						</tr>
					</xsl:for-each>
				</table>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>